using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.IServices;
using DAL.IRepositories;
using DAL.Models;

namespace BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int? id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsyncTask(id);
        }

        public Task AddNewAppointment(Appointment appointment)
        {
            return _appointmentRepository.CreateNewAppointment(appointment);
        }

        public Task DeleteAppointment(int id)
        {
            return _appointmentRepository.DeleteAppointment(id);
        }

        public Task UpdateAppointment(int id, Appointment appointment)
        {
            return _appointmentRepository.UpdateAppointment(id, appointment);
        }

        public bool CheckIfAppointmentExists(int? id)
        {
            return _appointmentRepository.CheckIfAppointmentExists(id);
        }

        public Task BookAppointment(int id, Appointment appointment)
        {
            return _appointmentRepository.BookAppointment(id, appointment);
        }
    }
}
