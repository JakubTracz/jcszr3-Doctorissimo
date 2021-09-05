using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Models;

namespace BLL.IServices
{
    public interface IAppointmentService
    {
        public Task<List<AppointmentDTO>> GetAllAsync();
        public Task<AppointmentDTO> GetByIdAsync(int? id);
        public Task CreateAsync(AppointmentDTO appointmentDto);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(int id, AppointmentDTO appointmentDto);
        public bool CheckIfExists(int? id);
        public Task AssignPatientToAppointment(int id,int patientId);
        public AppointmentDTO PopulateAppointmentModel(CreateAppointmentViewModel createAppointmentViewModel);
        public Task<List<AppointmentDTO>> GetAllAppointments();
    }
}
