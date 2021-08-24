using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.IServices
{
    public interface IAppointmentService
    {
        public Task<List<Appointment>> GetAllAppointments();
        public Task<Appointment> GetAppointmentByIdAsync(int? id);
        public Task AddNewAppointmentAsync(Appointment appointment);
        public Task DeleteAppointmentAsync(int id);
        public Task UpdateAppointmentAsync(int id, Appointment appointment);
        public bool CheckIfAppointmentExists(int? id);
        
    }
}
