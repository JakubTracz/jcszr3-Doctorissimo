using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Data;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AppointmentRepository:GenericRepository<Appointment>,IAppointmentRepository
    {
        public AppointmentRepository(DoctorissimoContext dbContext) : base(dbContext)
        {
        }

        public Task<Appointment> GetAppointmentByIdAsync(int? id)
        {
            return GetByIdAsync(id);
        }

        public Task CreateNewAppointmentAsync(Appointment appointment)
        {
            return CreateAsync(appointment);
        }

        public Task DeleteAppointmentAsync(int id)
        {
            return DeleteAsync(id);
        }

        public Task UpdateAppointmentAsync(int id, Appointment appointment)
        {
            return UpdateAsync(id, appointment);
        }

        public bool CheckIfAppointmentExists(int? id)
        {
            return CheckIfExists(id);
        }

        public Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return GetAll().ToListAsync();
        }
    }
}
