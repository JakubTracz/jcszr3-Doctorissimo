using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.IRepositories
{
    public interface IAppointmentRepository:IGenericRepository<Appointment>
    {
        Task<List<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsyncTask(int? id);
        public Task CreateNewAppointment(Appointment appointment);
        public Task DeleteAppointment(int id);
        public Task UpdateAppointment(int id,Appointment appointment);
        public bool CheckIfAppointmentExists(int? id);
        
    }
}
