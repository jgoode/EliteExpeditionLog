using System;
using System.Collections.Generic;
using System.Linq;
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

        public static double GetTotalDistance(Expedition expedition) {
            double sum = 0;
            using (var db = new EelContext()) {
                sum = (from p in db.StarSystems.Include("Expeditions")
                       where p.Expedition.Id == expedition.Id
                       select p.DistToNext).Sum();
            }
            return sum;
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
            List<SystemGridRow> result = new List<SystemGridRow>();
            using (var db = new EelContext()) {
                starSystems = (from p in db.StarSystems.Include("Expeditions")
                               where p.Expedition.Id == currentExpedition.Id
                               orderby p.CreatedAt descending
                               select p).Take(numberToReturn).ToList();

                foreach(var system in starSystems) {
                    int count = (from q in db.SystemObjects
                                 where q.StarSystem.Id == system.Id
                                 select q).Count();

                    var row = new SystemGridRow();
                    row.Date = system.CreatedAt;
                    row.Distance = system.DistToNext;
                    row.Name = system.Name;
                    row.HasSystemObjects = count > 0;
                    row.Id = system.Id;
                    result.Add(row);
                }
            }

            return result;
        }
    }
}
