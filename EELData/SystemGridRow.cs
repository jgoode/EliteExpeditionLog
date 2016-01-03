using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EELData {
    public class SystemGridRow {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public bool HasSystemObjects { get; set; }
    }
}
