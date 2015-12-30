using EELData;
using System.Collections.Generic;
using System.Linq;

namespace EELServices {
    public class SystemServices {
        public static List<EELData.System> GetAllSystems() {
            var systems = new List<EELData.System>();
            using (var db = new EelContext()) {
                systems = (from p in db.Systems
                           select p).ToList();
            }
            return systems;
        }
    }
}
