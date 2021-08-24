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
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        public Task AddNewAppointmentAsync(Appointment appointment)
        {
            return _appointmentRepository.CreateNewAppointmentAsync(appointment);
        }

        public Task DeleteAppointmentAsync(int id)
        {
            return _appointmentRepository.DeleteAppointmentAsync(id);
        }

        public Task UpdateAppointmentAsync(int id, Appointment appointment)
        {
            return _appointmentRepository.UpdateAppointmentAsync(id, appointment);
        }

        public bool CheckIfAppointmentExists(int? id)
        {
            return _appointmentRepository.CheckIfAppointmentExists(id);
        }


    }
}
