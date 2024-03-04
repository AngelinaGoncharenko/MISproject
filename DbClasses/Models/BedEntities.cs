namespace DbClasses.Models
{
    public class BedEntities
    {
        public int id { get; set; }
        public int roomNumber { get; set; }
        public string bedCode { get; set; }
        public virtual PatientEntities patient { get; set; }
    }
}

