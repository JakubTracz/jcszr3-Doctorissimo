using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Models.ViewModels;

namespace BLL.IServices
{
    public interface IAppointmentService
    {
        public Task<List<Appointment>> GetAllAsync();
        public Task<Appointment> GetByIdAsync(int? id);
        public Task CreateAsync(Appointment appointment);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(int id, Appointment appointment);
        public bool CheckIfExists(int? id);
        public Task AssignPatientToAppointment(int id,int patientId);
        public Appointment PopulateAppointmentModel(CreateAppointmentViewModel createAppointmentViewModel);
        public Task<List<AppointmentsListViewModel>> GetAppointmentsWithDoctorsAsync();
    }
}
