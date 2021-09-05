using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.IServices;
using DAL.Enums;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

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

        public Task<List<AppointmentDTO>> GetAllAsync() =>
            _appointmentRepository.GetAll().Select(a => new AppointmentDTO
            {
                RoomDto = new RoomDTO { Id = a.RoomId, Name = a.Room.Name },
                PatientDto = new PatientDTO
                {
                    Id = a.Patient.Id,
                    MailAddress = a.Patient.MailAddress,
                    DateOfBirth = a.Patient.DateOfBirth,
                    Address = a.Patient.Address,
                    LastName = a.Patient.LastName,
                    FirstName = a.Patient.FirstName,
                },
                DoctorDto = new DoctorDTO()
                {
                    Id = a.Doctor.Id,
                    LastName = a.Doctor.LastName,
                    FirstName = a.Doctor.FirstName,
                    Specialty = a.Doctor.Specialty,
                },
                AppointmentStatus = a.AppointmentStatus,
                AppointmentTime = a.AppointmentTime,
                Id = a.Id
            }).ToListAsync();

        public async Task<AppointmentDTO> GetByIdAsync(int? id)
        {
            var result = await _appointmentRepository.GetAppointmentByIdAsync(id);
            return new AppointmentDTO()
            {
              
            };
        }

        public Task CreateAsync(AppointmentDTO appointmentDto)
        {
            return _appointmentRepository.CreateNewAppointmentAsync(appointmentDto);
        }

        public Task DeleteAsync(int id)
        {
            return _appointmentRepository.DeleteAppointmentAsync(id);
        }

        public Task UpdateAsync(int id, AppointmentDTO appointmentDto)
        {
            return _appointmentRepository.UpdateAppointmentAsync(id, appointmentDto);
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

        public AppointmentDTO PopulateAppointmentModel(CreateAppointmentViewModel createAppointmentViewModel)
        {
            var appointment = createAppointmentViewModel.Appointment;
            appointment.AppointmentStatus = AppointmentStatus.Available;
            appointment.DoctorId = createAppointmentViewModel.SelectedDoctorId;
            appointment.RoomId = createAppointmentViewModel.SelectedRoomId;
            appointment.PatientId = null;
            return appointment;
        }

        public Task<List<AppointmentDTO>> GetAllAppointments() =>
            _appointmentRepository.GetAll().Select(a => new AppointmentDTO
            {
                RoomDto = new RoomDTO { Id = a.RoomId, Name = a.Room.Name },
                PatientDto = new PatientDTO
                {
                    Id = a.Patient.Id,
                    MailAddress = a.Patient.MailAddress,
                    DateOfBirth = a.Patient.DateOfBirth,
                    Address = a.Patient.Address,
                    LastName = a.Patient.LastName,
                    FirstName = a.Patient.FirstName,
                },
                DoctorDto = new DoctorDTO()
                {
                    Id = a.Doctor.Id,
                    LastName = a.Doctor.LastName,
                    FirstName = a.Doctor.FirstName,
                    Specialty = a.Doctor.Specialty,
                },
                AppointmentStatus = a.AppointmentStatus,
                AppointmentTime = a.AppointmentTime,
                Id = a.Id
            }).ToListAsync();
    }
}
