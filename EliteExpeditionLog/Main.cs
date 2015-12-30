using EELData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EELServices;
using System.Diagnostics;

namespace EliteExpeditionLog {
    public partial class Main : Form {
        #region Fields
        private string _dataPath;
        private LogFileHandler _logFileHandler;
        private static RichTextBox static_richTextBox;
        private static DataGridView static_grid;
        private Settings _settings;
        private static IEnumerable<Expedition> _expeditions;
        private static Expedition _currentExpedition;
        //private static List<SystemObject> _systemObjects;
        private static StarSystem _currentStarSystem;
        private static bool _userSelectsExpedition;
        private static BindingList<SystemObject> _systemObjects = new BindingList<SystemObject>();
        private static TextBox _xtext;
        private static TextBox _ytext;
        private static TextBox _ztext;
        private static Label _systemLabel;
        private static CheckBox _refuel;
        private static CheckBox _bookmark;
        private static CheckBox _discovered;
        private static TextBox _distToNext;
        public static List<EELData.System> Systems;  // Make available Application wide

        #endregion

        #region Ctor
        public Main() {
            InitializeComponent();
            //LogRichText("Initializing...", Color.DarkGreen);

            if (!File.Exists("eel.db")) {
                InitializeDb();
            }
            BindStaticControls();
            RefreshScannedObjectsList();
            GetSettings();
            if (_settings == null) {
                _settings = new Settings {
                    Commander = "The Mule",
                    LogPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Frontier_Developments\\Products\\elite-dangerous-64\\Logs"
                };
            }
            RefreshSettings();
            GetLogPath();
            if (!string.IsNullOrWhiteSpace(_dataPath)) {
                LogWatcher.Path = _dataPath;
                LogWatcher.EnableRaisingEvents = true;
            }
            RefreshExpeditionDropDown();
            PopulateSystemGrid();
            PopulateObjectTypes();
            GetDistanceTravelled();
            _logFileHandler = new LogFileHandler(_currentExpedition);
            LoadSystems();

        }
        
        #endregion

        #region Methods

        private void LoadSystems() {
            LogRichText("Start loading Systems...", Color.Red);
            LoadSystemsWorker.RunWorkerAsync();
        }

        private void GetDistanceTravelled() {
            var total = StarSystemServices.GetTotalDistance(_currentExpedition);
            TotalDistanceText.Text = total.ToString("###0.00");
        }
        private void RefreshSettings() {
            this.Text = string.Format("Elite Expedition Log [{0}] - Commander: {1}", "0.15.12221", _settings.Commander);
        }

        private void GetSettings() {
            _settings = SettingsServices.GetSettings();
        }

        private void BindStaticControls() {
            static_grid = VisitedSystemsGrid;
            static_richTextBox = LogText;
            _xtext = XText;
            _ytext = YText;
            _ztext = ZText;
            _systemLabel = SystemLabel;
            _refuel = Refuel;
            _bookmark = Bookmark;
            _discovered = Discovered;
            _distToNext = DistToNextText;
        }

        private  void PopulateSystemGrid() {
            if (_currentExpedition == null) return;
            var data = StarSystemServices.GetLastNSystems(_currentExpedition);

            static_grid.DataSource = StarSystemServices.GetLastNSystems(_currentExpedition);
            static_grid.Columns[1].Width = 150;
            static_grid.Columns[2].Width = 330;
            static_grid.Columns[3].Width = 68;
            static_grid.Columns[0].Visible = false;
            SystemGridRow row = null;
            if (data.Count < 1) return;
            row = (SystemGridRow)static_grid.Rows[0].DataBoundItem;
            //_currentStarSystem = StarSystemServices.GetByStarSystemId(row.Id);
            //RefreshStarSystemControls();
        }

        private  void RefreshStarSystemControls() {
            _xtext.Text = _currentStarSystem.X.ToString("###0.00");
            _ytext.Text = _currentStarSystem.Y.ToString("###0.00");
            _ztext.Text = _currentStarSystem.Z.ToString("###0.00");
            _systemLabel.Text = _currentStarSystem.Name;
            _refuel.Checked = _currentStarSystem.Refuel;
            _discovered.Checked = _currentStarSystem.Discovered;
            _bookmark.Checked = _currentStarSystem.IsBookMarked;
            DistanceTravelled.Text = _currentStarSystem.DistToNext.ToString("###0.00");
            _systemObjects = new BindingList<SystemObject>(SystemObjectServices.GetByStarSystemId(_currentStarSystem.Id));
            RefreshScannedObjectsList();
            GetDistanceTravelled();
        }

        private void RefreshExpeditionDropDown() {
            _userSelectsExpedition = false;
            if (null == _expeditions) {
                _expeditions = ExpeditionServices.GetAll();
            }
            Expeditions.DataSource = _expeditions.ToList();
            Expeditions.DisplayMember = "Name";
            var currentExpedition = _expeditions.Where(a => a.Current).FirstOrDefault();
            int itemIndex = -1;
            for (int index = 0; index < Expeditions.Items.Count; index++) {
                var exp = (Expedition)Expeditions.Items[index];
                if (exp.Id == currentExpedition.Id) {
                    itemIndex = index;
                    _currentExpedition = exp;
                    break;
                }
            }
            Expeditions.SelectedIndex = itemIndex;
            PopulateSystemGrid();
            _userSelectsExpedition = true;
        }

        private void GetLogPath() {
            var productDir = _settings.LogPath;
            DirectoryInfo dirInfo = new DirectoryInfo(productDir);
            FileInfo[] allFiles = dirInfo.GetFiles("netLog*.log", SearchOption.AllDirectories);
            if (allFiles != null) {
                var lastFile = allFiles[allFiles.Length - 1];
                _dataPath = lastFile.DirectoryName;
            }
        }

        /// <summary>
        /// Initialize the database and seed the ObjectType table
        /// </summary>
        private void InitializeDb() {
            using (var db = new EelContext()) {
                db.Database.EnsureCreated();
                var objectTypes = new List<ObjectType> {
                    new ObjectType {Order = 1, Name = "Star (F/G/K/M)", LowValue=2400, HighValue = 6600, MedianValue=4500},
                    new ObjectType {Order = 2, Name = "Star (Other)", LowValue = 2400, HighValue=6600,MedianValue=4500},
                    new ObjectType {Order = 3, Name = "Black Hole" ,LowValue=38000, HighValue=50000,MedianValue=44000},
                    new ObjectType {Order = 4, Name = "Neutron Star" ,LowValue=36000, HighValue=38000,MedianValue=37000},
                    new ObjectType {Order = 5, Name = "White Dwarf" ,LowValue=26000, HighValue=26000,MedianValue=26000},
                    new ObjectType {Order = 6, Name = "Wolf-Rayet Star" ,LowValue=3000, HighValue=6600,MedianValue=4800},
                    new ObjectType {Order = 7, Name = "Carbon Star" ,LowValue=2400, HighValue=2400,MedianValue=2400},
                    new ObjectType {Order = 8, Name = "Proto Star (Ae/Be/T-Tauri)",LowValue=2400, HighValue=3000,MedianValue=2700 },
                    new ObjectType {Order = 9, Name = "Water World ",LowValue=18000, HighValue=36000,MedianValue=27000},
                    new ObjectType {Order = 10, Name = "Water World Terraformable",LowValue=27000, HighValue=65000,MedianValue=46000},
                    new ObjectType {Order = 11, Name = "Earth-like",LowValue=54000, HighValue=62000,MedianValue=58000},
                    new ObjectType {Order = 12, Name = "Ammonia",LowValue=33000, HighValue=35000,MedianValue=34000},
                    new ObjectType {Order = 13, Name = "Metal-Rich",LowValue=9000, HighValue=14000,MedianValue=11500},
                    new ObjectType {Order = 14, Name = "High Metal Content",LowValue=4100, HighValue=8500,MedianValue=6300},
                    new ObjectType {Order = 15, Name = "Terraformable High Metal",LowValue=30000, HighValue=45000,MedianValue=37500},
                    new ObjectType {Order = 16, Name = "Gas Giant Class I",LowValue=2200, HighValue=3800,MedianValue=3000},
                    new ObjectType {Order = 17, Name = "Gas Giant Class II",LowValue=7500, HighValue=12300,MedianValue=9900},
                    new ObjectType {Order = 18, Name = "Gas Giant Class III",LowValue=2200, HighValue=3800,MedianValue=3000},
                    new ObjectType {Order = 19, Name = "Gas Giant Class IV",LowValue=2200, HighValue=3800,MedianValue=3000},
                    new ObjectType {Order = 20, Name = "Gas Giant Class V",LowValue=2200, HighValue=3800,MedianValue=3000},
                    new ObjectType {Order = 21, Name = "Rocky/Icy Planet",LowValue=600, HighValue=1200,MedianValue=900},

                };
                for (var i = 0; i < objectTypes.Count; i++) {
                    db.ObjectTypes.Add(objectTypes[i]);
                }
                //objectTypes.ForEach(p => db.ObjectTypes.Add(p));
                db.SaveChanges();
            }
        }

        private void PopulateObjectTypes() {
            using (var db = new EelContext()) {

                var objectTypes = (from p in db.ObjectTypes
                                   orderby p.Order
                                   select p).ToList();

                ObjectTypesList.DataSource = objectTypes;
                ObjectTypesList.DisplayMember = "Name";
                ObjectTypesList.ValueMember = "Id";

            }
        }

        static void LogRichText(string text) {
            Main.LogRichText(text, Color.Black);
        }

        static void LogRichText(string text, Color color) {
            try {

                static_richTextBox.SelectionStart = static_richTextBox.TextLength;
                static_richTextBox.SelectionLength = 0;

                static_richTextBox.SelectionColor = color;
                static_richTextBox.AppendText(text);
                static_richTextBox.AppendText("\n");
                static_richTextBox.SelectionColor = static_richTextBox.ForeColor;

                static_richTextBox.SelectionStart = static_richTextBox.Text.Length;
                static_richTextBox.SelectionLength = 0;
                static_richTextBox.ScrollToCaret();
                static_richTextBox.Refresh();
            } catch (Exception ex) {
                Trace.WriteLine("Exception SystemClass: " + ex.Message);
                Trace.WriteLine("Trace: " + ex.StackTrace);
            }
        }

        private void AddStarSystemObject(ObjectType selectedObjectType) {
            var newSystemObject = new SystemObject();
            newSystemObject.Landing = false;
            newSystemObject.StarSystem = _currentStarSystem;
            newSystemObject.Name = selectedObjectType.Name;
            newSystemObject.ObjectType = selectedObjectType;
            newSystemObject = SystemObjectServices.InsertSystemObject(newSystemObject);
            _systemObjects.Add(newSystemObject);
        }

        private void RefreshScannedObjectsList() {
            //ScannedObjectsList.Items.Clear();
            ScannedObjectsList.DataSource = _systemObjects;
            ScannedObjectsList.DisplayMember = "Name";
            ScannedObjectsList.ValueMember = "Id";

        } 
        #endregion

        /* ********************** Form Events **************************/
        #region StripMenuEvents
        private void pathsToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            var settingsForm = new SettingsForm(_settings);
            if (settingsForm.ShowDialog() == DialogResult.OK) {
                _settings = SettingsServices.UpdateSettings(settingsForm.Settings);
                RefreshSettings();
            }
        }
        #endregion

        #region Log Watcher Events
        private void LogWatcher_Changed(object sender, FileSystemEventArgs e) {
            if (e.ChangeType == WatcherChangeTypes.Changed) {

                try {
                    LogWatcher.EnableRaisingEvents = false;
                    var system = _logFileHandler.RetrieveNextStarSystem(new FileInfo(e.FullPath));
                    if (null != system) {

                        if (!StarSystemServices.SystemPreviouslyVisited(system.Name)) {

                            if (!string.IsNullOrWhiteSpace(DistToNextText.Text)) {
                                double distToNext = 0;
                                if (double.TryParse(DistToNextText.Text, out distToNext)) {
                                    system.DistToNext = distToNext;
                                    DistToNextText.Clear();
                                }
                            }

                            system.Visits = 1;
                            var savedSystem = StarSystemServices.InsertStarSystem(system);
                            if (null != savedSystem) {
                                Main.LogRichText(string.Format("Arrival at System: {0}", savedSystem.Name), Color.Blue);
                                _systemObjects = new BindingList<SystemObject>();
                                SystemLabel.Text = savedSystem.Name;
                                PopulateSystemGrid();
                            }
                        } else {
                            Main.LogRichText(string.Format("Arrival at System: {0} - Previously Visited", system.Name), Color.Navy);
                        }

                    }
                } finally {
                    LogWatcher.EnableRaisingEvents = true;
                }
            }
        } 

        #endregion

        #region AddExpedition Button Events
        private void AddExpedition_Click(object sender, EventArgs e) {
            var addExpeditionForm = new AddExpedition(ExpeditionFormType.Add, _settings);
            if (addExpeditionForm.ShowDialog() == DialogResult.OK) {
                if (null == addExpeditionForm.Expedition) return;

                var expedition = addExpeditionForm.Expedition;

                var match = (from p in _expeditions
                             where p.Name == expedition.Name
                             select p).FirstOrDefault();

                if (match != null) return;

                List<Expedition> temp = new List<Expedition>();
                foreach (var exp in _expeditions) {
                    exp.Current = false;
                    temp.Add(exp);
                }

                ExpeditionServices.ClearExpeditionCurrentFlags();
                var expSaved = ExpeditionServices.InsertExpedition(expedition);
                temp.Add(expSaved);
                _expeditions = temp;
                LogRichText(string.Format("Added expedition {0} ({1})...", expSaved.Name, expSaved.Id), Color.Red);
                RefreshExpeditionDropDown();
            }
        }
        #endregion

        #region Edit Expedition Button Events
        private void EditExpeditionButton_Click(object sender, EventArgs e) {

        }
        #endregion

        #region Expeditions Dropdown Events
        private void Expeditions_SelectedIndexChanged(object sender, EventArgs e) {
            _currentExpedition = (Expedition)Expeditions.SelectedItem;
            PopulateSystemGrid();
        }
        #endregion

        #region ObjectTypesList Events
        private void ObjectTypesList_DoubleClick(object sender, EventArgs e) {
            var selectedObjectType = (ObjectType)ObjectTypesList.SelectedItem;
            if (null == selectedObjectType) return;
            AddStarSystemObject(selectedObjectType);
        }
        #endregion

        #region Refuel Events
        private void Refuel_Click(object sender, EventArgs e) {
            _currentStarSystem.Refuel = Refuel.Checked;
           // _currentStarSystem.Expedition = _currentExpedition;
            _currentStarSystem = StarSystemServices.UpdateStarSystem(_currentStarSystem);
        }
        #endregion

        #region Bookmark Events
        private void Bookmark_Click(object sender, EventArgs e) {
            _currentStarSystem.IsBookMarked = Bookmark.Checked;
            _currentStarSystem = StarSystemServices.UpdateStarSystem(_currentStarSystem);
        }
        #endregion

        #region Discovered Events
        private void Discovered_Click(object sender, EventArgs e) {
            _currentStarSystem.Discovered = Discovered.Checked;
            _currentStarSystem = StarSystemServices.UpdateStarSystem(_currentStarSystem);
        }
        #endregion

        #region VisitedSystemsGrid Events
        private void VisitedSystemsGrid_SelectionChanged(object sender, EventArgs e) {

        }

        private void VisitedSystemsGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e) {
            if (e.StateChanged != DataGridViewElementStates.Selected) return;
            var row = (SystemGridRow)e.Row.DataBoundItem;
            _currentStarSystem = StarSystemServices.GetByStarSystemId(row.Id);
            RefreshStarSystemControls();
        }
        #endregion

        #region LoadSystemsWorker Events
        private void LoadSystemsWorker_DoWork(object sender, DoWorkEventArgs e) {
            Systems = new List<EELData.System>();
            Systems = SystemServices.GetAllSystems();
        }

        private void LoadSystemsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            LogRichText(string.Format("Completed loading {0} Systems...", Systems.Count()), Color.DarkRed);
        } 
        #endregion
    }
}
