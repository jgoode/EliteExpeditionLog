using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EELData;

namespace EELServices {
    public class ExpeditionServices {
        public static List<Expedition> GetAll() {
            var exp = new List<Expedition>();
            using (var db = new EelContext()) {
                exp = (from p in db.Expeditions
                        select p).ToList();
            }
            return exp;
        }

        public static void ClearExpeditionCurrentFlags() {
            using (var db = new EelContext()) {
                var exps = (from p in db.Expeditions
                            where p.Current
                        select p);

                foreach(var exp in exps) {
                    exp.Current = false;
                }

                db.SaveChanges();
            }
        }

        public static Expedition InsertExpedition(Expedition expedition) {
            if (null == expedition) throw new ArgumentNullException("expedition");
            using (var db = new EelContext()) {
                db.Expeditions.Add(expedition);
                db.SaveChanges();
            }
            return expedition;
        }
    }
}
