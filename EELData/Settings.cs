using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EELData {
    public class Settings {
        public string LogPath { get; set; }
        public string EdsmKey { get; set; }
        [Key]
        public string Commander { get; set; }
    }
}
