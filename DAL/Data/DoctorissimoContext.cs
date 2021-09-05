using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class DoctorissimoContext : DbContext
    {
        public DoctorissimoContext (DbContextOptions<DoctorissimoContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DoctorissimoContext-8c692097-a331-41dd-a4fa-bd7096770176;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicalTest> MedicalTests { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
