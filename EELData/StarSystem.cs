using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EELData {
    public class StarSystem {
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
        public bool CoordinatesSubmitted { get; set; }
        public bool Refuel { get; set; }

        public virtual Expedition Expedition { get; set; }
        public virtual ICollection<SystemObject> SystemObjects { get; set; }

    }
}
