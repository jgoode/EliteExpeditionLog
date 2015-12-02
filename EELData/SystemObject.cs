namespace EELData {
    public class SystemObject {
        public int Id { get; set; }
        public bool Landing { get; set; }

        public virtual ObjectType ObjectType { get; set; }
    }
}