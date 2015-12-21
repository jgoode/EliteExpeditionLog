using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EELData {
    public class StarSystem {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ObjectId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double DistToNext { get; set; }
        public bool IsBookMarked { get; set; }
        public bool Discovered { get; set; }
        public bool CoordinatesSubmitted { get; set; }
        public bool Refuel { get; set; }
        public int Visits { get; set; }
        public int ExpeditionId { get; set; }
        public Expedition Expedition { get; set; }
        public ICollection<SystemObject> SystemObjects { get; set; }

    }
}
