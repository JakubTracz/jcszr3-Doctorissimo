using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IPatientRepository patientRepository, IMapper mapper, IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        public async Task<List<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsAsync();
            var doctors = appointments
            {
              Id  = a.DoctorId,
              FirstName = a.Doctor.FirstName,

            }
            return appointments.Select(a => new AppointmentDto
            {
                RoomDto =_mapper.Map<Room,RoomDto>(a.Room),
                PatientDto = _mapper.Map<Patient,PatientDto>(a.Patient),
                DoctorDto = _mapper.Map<Doctor,DoctorDto>(a.Doctor),
                AppointmentStatus = a.AppointmentStatus,
                AppointmentTime = a.AppointmentTime,
                Id = a.Id
            }).ToList();
        }

        public async Task<AppointmentDto> GetByIdAsync(int? id)
        {
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);
            var appointmentDto = _mapper.Map<Appointment, AppointmentDto>(appointment);
            var doctor = await _doctorRepository.GetDoctorByIdAsyncTask(appointment.DoctorId);
            var patient = await _patientRepository.GetPatientByIdAsync(appointment.PatientId);
            appointmentDto.DoctorDto = _mapper.Map<Doctor, DoctorDto>(doctor);
            appointmentDto.PatientDto = _mapper.Map<Patient, PatientDto>(patient);

            return appointmentDto;
            //    new AppointmentDto
            //{
            //    AppointmentStatus = appointment.AppointmentStatus,
            //    AppointmentTime = appointment.AppointmentTime,
            //    DoctorDto = doctorDto,
            //    PatientDto = new PatientDto
            //    {
            //        MailAddress = appointment.Patient.MailAddress,
            //        FirstName = appointment.Patient.FirstName,
            //        LastName = appointment.Patient.LastName,
            //        Id = appointment.Patient.Id,
            //        Address = appointment.Patient.Address,
            //        DateOfBirth = appointment.Patient.DateOfBirth
            //    },
            //    RoomDto = new RoomDto
            //    {
            //        Id = appointment.Room.Id,
            //        Name = appointment.Room.Name
            //    },
            //    Id = appointment.Id
            //};
        }

     public Task CreateAsync(AppointmentDto appointmentDto)
        {
            var appointment = new Appointment
            {
                AppointmentTime = appointmentDto.AppointmentTime,
                RoomId = appointmentDto.RoomDto.Id,
                DoctorId = appointmentDto.DoctorDto.Id
            };
            return _appointmentRepository.CreateNewAppointmentAsync(appointment);
        }
        public Task DeleteAsync(int id) => _appointmentRepository.DeleteAppointmentAsync(id);
        public Task UpdateAsync(int id, AppointmentDto appointmentDto)
        {
            var appointment = new Appointment()
            {
                RoomId = appointmentDto.RoomDto.Id,
                AppointmentStatus = appointmentDto.AppointmentStatus,
                AppointmentTime = appointmentDto.AppointmentTime,
                DoctorId = appointmentDto.DoctorDto.Id,
                Id = appointmentDto.Id,
                PatientId = appointmentDto.PatientDto.Id,
            };
            return _appointmentRepository.UpdateAppointmentAsync(id, appointment);
        }

        public bool CheckIfExists(int? id) => _appointmentRepository.CheckIfAppointmentExists(id);
        public async Task AssignPatientToAppointment(int id, int patientId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            var patient = await _patientRepository.GetPatientByIdAsync(patientId);
            appointment.PatientId = patient.Id;
            appointment.AppointmentStatus = AppointmentStatus.Booked;
            await _appointmentRepository.UpdateAppointmentAsync(id, appointment);
        }
    }
}
