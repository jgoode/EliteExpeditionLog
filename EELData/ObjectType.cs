using System.ComponentModel.DataAnnotations.Schema;

namespace EELData {
    public class ObjectType {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double LowValue { get; set; }
        public double HighValue { get; set; }
        public double MedianValue { get; set; }
        public int Order { get; set; }
    }
}