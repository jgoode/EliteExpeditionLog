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

namespace EliteExpeditionLog {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
            if (!File.Exists("eel.db")) {
                InitializeDb();
            }
        }


        private void InitializeDb() {
            using (var db = new EelContext()) {
                db.Database.EnsureCreated();
            }
        }

    }
}
