using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.IRepositories
{
    public interface IAppointmentRepository:IGenericRepository<Appointment>
    {
        Task<List<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int? id);
        public Task CreateNewAppointmentAsync(Appointment appointment);
        public Task DeleteAppointmentAsync(int id);
        public Task UpdateAppointmentAsync(int id, Appointment appointment);
        public bool CheckIfAppointmentExists(int? id);
        public Task<List<Appointment>> GetAllAppointments();
    }
}
