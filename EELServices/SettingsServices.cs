using EELData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EELServices {
    public class SettingsServices {
        public static Settings InsertSettings(Settings settings) {
            if (null == settings) throw new ArgumentNullException("settings");
            using (var db = new EelContext()) {
                db.Settings.Add(settings);
                db.SaveChanges();
            }
            return settings;
        }

        public static Settings UpdateSettings(Settings settings) {
            if (null == settings) throw new ArgumentNullException("expedition");
            using (var db = new EelContext()) {
                if (db.Settings.Count() > 0) {
                    db.Settings.Attach(settings);
                    db.Entry(settings).State = Microsoft.Data.Entity.EntityState.Modified;
                } else {
                    db.Settings.Add(settings);
                }
                
                db.SaveChanges();
            }
            return settings;
        }

        public static Settings GetSettings() {
            Settings settings = null;
            using (var db = new EelContext()) {
                settings = (from p in db.Settings
                            select p).FirstOrDefault();
            }
            return settings;
        }
    }
}
