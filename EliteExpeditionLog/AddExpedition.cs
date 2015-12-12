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
using EELServices;

namespace EliteExpeditionLog {

    public enum ExpeditionFormType {
        Add = 0,
        Edit
    }

    public partial class AddExpedition : Form {
        private readonly Settings _settings;

        public Expedition Expedition
        {
            get
            {
                var expedition = new Expedition();
                expedition.Name = NameTextBox.Text;
                expedition.Description = DescriptionTextBox.Text;
                expedition.StartDate = StartDatePicker.Value.Date;
                expedition.EndDate = EndDatePicker.Value.Date;
                expedition.StartSystem = StartSystemTextBox.Text;
                expedition.EndSystem = EndSystemTextBox.Text;
                expedition.User = _settings.Commander;
                expedition.Current = true;
                return expedition;
            }
        }
        public AddExpedition(ExpeditionFormType formType, Settings settings) {
            if (null == settings) throw new ArgumentNullException("settings");
            InitializeComponent();
            _settings = settings;
            if (formType == ExpeditionFormType.Add) {
                this.Text = "Add Expedition";
            } else {
                this.Text = "Edit Expedition";
            }
        }

        private void SaveButton_Click(object sender, EventArgs e) {

        }
    }
}
