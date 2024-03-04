namespace DbClasses.Models
{
    public class EventEntities
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual TypeEventEntities typeEvent { get; set; }
    }
}

