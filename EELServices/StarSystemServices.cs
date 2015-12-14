using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EELData;

namespace EELServices {
    public class StarSystemServices {
        public static StarSystem InsertStarSystem(StarSystem system) {
            if (null == system) throw new ArgumentNullException("expedition");
            using (var db = new EelContext()) {
                db.StarSystems.Add(system);
                db.SaveChanges();
            }
            return system;
        }

        public static List<SystemGridRow> GetLastNSystems(int numberToReturn = 20) {
            List<StarSystem> starSystems = null;
            using (var db = new EelContext()) {
                starSystems = (from p in db.StarSystems
                               orderby p.CreatedAt descending
                               select p).Take(numberToReturn).ToList();
            }

            return (from p in starSystems
                    orderby p.CreatedAt descending
                    select new SystemGridRow {
                        Date = p.CreatedAt,
                        Distance = p.DistToNext,
                        Name = p.Name,
                        Id = p.Id
                    }).ToList();
        }
    }
}
