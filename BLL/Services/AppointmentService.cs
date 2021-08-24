using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.IServices;
using DAL.Enums;
using DAL.IRepositories;
using DAL.Models;

namespace BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository,IPatientRepository patientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
        }

        public async Task<List<Appointment>> GetAll()
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

        public async Task AssignPatientToAppointment(int id, string patientMail)
        {
            var appointment = await GetAppointmentByIdAsync(id);
            var patient = await _patientRepository.GetPatientByEmail(patientMail);
            appointment.PatientId = patient.Id;
            appointment.AppointmentStatus = AppointmentStatus.Booked;
            await _appointmentRepository.UpdateAppointmentAsync(id, appointment);
        }
    }
}
