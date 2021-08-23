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

        public Task<Appointment> GetAppointmentByIdAsyncTask(int? id)
        {
            return GetByIdAsync(id);
        }

        public Task CreateNewAppointment(Appointment appointment)
        {
            return CreateAsync(appointment);
        }

        public Task DeleteAppointment(int id)
        {
            return DeleteAsync(id);
        }

        public Task UpdateAppointment(int id, Appointment appointment)
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
