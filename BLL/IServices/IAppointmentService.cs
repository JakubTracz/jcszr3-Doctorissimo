using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.IServices
{
    public interface IAppointmentService
    {
        public Task<AppointmentDto> GetByIdAsync(int? id);
        public Task CreateAsync(AppointmentDto appointmentDto);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(int id, AppointmentDto appointmentDto);
        public bool CheckIfExists(int? id);
        public Task AssignPatientToAppointment(int id,int patientId);
        public Task<List<AppointmentDto>> GetAllAppointmentsAsync();
    }
}
