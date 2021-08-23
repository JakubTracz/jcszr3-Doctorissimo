using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.IServices
{
    public interface IAppointmentService
    {
        public Task<List<Appointment>> GetAllAppointments();
        public Task<Appointment> GetAppointmentByIdAsync(int? id);
        public Task AddNewAppointment(Appointment appointment);
        public Task DeleteAppointment(int id);
        public Task UpdateAppointment(int id, Appointment appointment);
        public bool CheckIfAppointmentExists(int? id);
        public Task BookAppointment(int id, Appointment appointment);
    }
}
