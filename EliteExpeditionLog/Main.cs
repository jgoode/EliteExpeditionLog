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
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            InitializeDb();
        }

        private void InitializeDb() {
            using (var db = new EelContext()) {
                db.Database.EnsureCreated();
            }
        }

        private void label3_Click(object sender, EventArgs e) {

        }
    }
}
