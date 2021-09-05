using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.IServices;
using DAL.Enums;
using DAL.IRepositories;
using DAL.Models;
using DAL.Models.ViewModels;

namespace BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IPatientRepository patientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }

        public async Task<Appointment> GetByIdAsync(int? id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        public Task CreateAsync(Appointment appointment)
        {
            return _appointmentRepository.CreateNewAppointmentAsync(appointment);
        }

        public Task DeleteAsync(int id)
        {
            return _appointmentRepository.DeleteAppointmentAsync(id);
        }

        public Task UpdateAsync(int id, Appointment appointment)
        {
            return _appointmentRepository.UpdateAppointmentAsync(id, appointment);
        }

        public bool CheckIfExists(int? id)
        {
            return _appointmentRepository.CheckIfAppointmentExists(id);
        }

        public async Task AssignPatientToAppointment(int id, int patientId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            var patient = await _patientRepository.GetPatientByIdAsync(patientId);
            appointment.PatientId = patient.Id;
            appointment.AppointmentStatus = AppointmentStatus.Booked;
            await _appointmentRepository.UpdateAppointmentAsync(id, appointment);
        }

        public Appointment PopulateAppointmentModel(CreateAppointmentViewModel createAppointmentViewModel)
        {
            var appointment = createAppointmentViewModel.Appointment;
            appointment.AppointmentStatus = AppointmentStatus.Available;
            appointment.DoctorId = createAppointmentViewModel.SelectedDoctorId;
            appointment.RoomId = createAppointmentViewModel.SelectedRoomId;
            appointment.PatientId = null;
            return appointment;
        }

        public async Task<List<AppointmentsListViewModel>> GetAppointmentsWithDoctorsAsync()
        {
            return await _appointmentRepository.GetAllAppointments();
        }
    }
}
