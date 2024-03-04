namespace DbClasses.Models
{
    public class MedCardEntities
    {
        public int id { get; set; }
        public DateTime dateCreateMedCard { get; set; }
        public virtual AppointmentEntities appointment { get; set; }
        public MedHistoryEntities medHistory { get; set; }
        public string photoPatients { get; set; }
    }
}

