using EELData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EELServices {
    public class SystemObjectServices {
        public static SystemObject InsertSystemObject(SystemObject systemObject) {
            if (null == systemObject) throw new ArgumentNullException("systemObject");
            using (var db = new EelContext()) {
                db.SystemObjects.Add(systemObject);
                db.SaveChanges();
            }
            return systemObject;
        }
    }
}
