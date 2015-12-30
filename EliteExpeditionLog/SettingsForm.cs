using EELData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteExpeditionLog {
    public partial class SettingsForm : Form {

        public Settings Settings { get; set; }

        public SettingsForm(Settings settings) {
            InitializeComponent();
            Settings = settings;
            if (null != settings) {
                CommanderNameText.Text = settings.Commander;
                EdsmKeyText.Text = settings.EdsmKey;
                LogFilePathText.Text = settings.LogPath;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            Settings.Commander = CommanderNameText.Text.Trim();
            Settings.EdsmKey = EdsmKeyText.Text.Trim();
            Settings.LogPath = LogFilePathText.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
