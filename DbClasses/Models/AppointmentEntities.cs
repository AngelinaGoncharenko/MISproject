namespace DbClasses.Models
{
    public class AppointmentEntities
    {
        public int Id { get; set; }
        public DateTime lastDate { get; set; }
        public DateTime NextDate { get; set; }
        public virtual DoctorEntities doctor { get; set; }
        public virtual DiagnosticsEntities diagnostics { get; set; }
    }
}

