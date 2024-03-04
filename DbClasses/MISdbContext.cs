using DbClasses.Models;
using System.Data.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DbClasses
{
    public class MISdbContext : DbContext
    {
        public MISdbContext()
            : base("Data Source=ANGELINA;Initial Catalog=MISdb;Integrated Security=True;")
        { }

        public DbSet<AccountEntities> Account { get; set; }
        public DbSet<AppointmentEntities> Appointment { get; set; }
        public DbSet<ConditionEntities> Condition { get; set; }
        public DbSet<DepartmentEntities> Department { get; set; }
        public DbSet<DiagnosisEntities> Diagnosis { get; set; }
        public DbSet<DiagnosticsEntities> Diagnostics { get; set; }
        public DbSet<DoctorEntities> Doctor { get; set; }
        public DbSet<EventEntities> Event { get; set; }
        public DbSet<GenderEntities> Gender { get; set; }
        public DbSet<HospitalizationEntities> Hospitalization { get; set; }
        public DbSet<MedCardEntities> MedCard { get; set; }
        public DbSet<MedHistoryEntities> MedHistory { get; set; }
        public DbSet<PaimentEntities> Paiment { get; set; }
        public DbSet<PatientEntities> Patient { get; set; }
        public DbSet<ProfessionEntity> Profession { get; set; }
        public DbSet<ReceptEntities> Recept { get; set; }
        public DbSet<StatusEntities> Status { get; set; }
        public DbSet<TypeEventEntities> TypeEvent { get; set; }
        public DbSet<TypeInsuranceEntities> TypeInsurance { get; set; }
        public DbSet<GovEntities> Gov { get; set; }
        public DbSet<RoleEntities> Role { get; set; }
        public DbSet<BedEntities> Bed { get; set; }
    }
}
