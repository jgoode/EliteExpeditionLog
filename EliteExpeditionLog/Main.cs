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
            PopulateObjectTypes();
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

    }
}
