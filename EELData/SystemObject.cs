using System.ComponentModel.DataAnnotations.Schema;

namespace EELData {
    public class SystemObject {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Landing { get; set; }
        public virtual StarSystem StarSystem { get; set; }
        public virtual ObjectType ObjectType { get; set; }
        public string Name { get; set; }
    }
}