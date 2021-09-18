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

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicalTest> MedicalTests { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
