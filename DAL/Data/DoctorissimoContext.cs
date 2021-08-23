using DAL.Models;
using DAL.Models.ViewModels;
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
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
    }
}
