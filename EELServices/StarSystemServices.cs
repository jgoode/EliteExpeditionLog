using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EELData;
using System.Data.Entity;

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

        public static StarSystem UpdateStarSystem(StarSystem system) {
            if (null == system) throw new ArgumentNullException("expedition");
            using (var db = new EelContext()) {
                system.UpdatedAt = DateTime.Now;
                db.StarSystems.Attach(system);
                db.Entry(system).State = Microsoft.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return system;
        }

        public static bool SystemPreviouslyVisited(string name) {
            bool visited = false;
            StarSystem system = null;
            using (var db = new EelContext()) {
                system = (from p in db.StarSystems
                          where p.Name.Trim() == name.Trim()
                          select p).FirstOrDefault();

                if (null != system) {
                    system.Visits += 1;
                    UpdateStarSystem(system);
                    visited = true;
                }
            }
            return visited;
        }

        public static StarSystem GetByStarSystemId(int id) {
            StarSystem starSystem = null;
            using (var db = new EelContext()) {
                starSystem = (from p in db.StarSystems.Include("Expedition")
                              where p.Id == id
                              select p).SingleOrDefault();

            }
            return starSystem;
        }

        public static List<SystemGridRow> GetLastNSystems(Expedition currentExpedition, int numberToReturn = 20) {
            List<StarSystem> starSystems = null;
            using (var db = new EelContext()) {
                starSystems = (from p in db.StarSystems.Include("Expeditions")
                               where p.Expedition.Id == currentExpedition.Id
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
