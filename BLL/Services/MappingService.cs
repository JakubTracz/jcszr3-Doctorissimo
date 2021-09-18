using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.IServices;
using DAL.Models;

namespace BLL.Services
{
    public class MappingService :IMappingService
    {
        private readonly IMapper _mapper;

        public MappingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Appointment MapAppointmentDtoToAppointment(AppointmentDto appointmentDto) => _mapper.Map<AppointmentDto, Appointment>(appointmentDto);
        public AppointmentDto MapAppointmentToAppointmentDto(Appointment appointment) => _mapper.Map<Appointment, AppointmentDto>(appointment);
        public Patient MapPatientDtoToPatient(PatientDto patientDto) => _mapper.Map<PatientDto, Patient>(patientDto);
        public PatientDto MapPatientToPatientDto(Patient patient) => _mapper.Map<Patient, PatientDto>(patient);
        public Doctor MapDoctorDtoToDoctor(DoctorDto doctorDto) => _mapper.Map<DoctorDto, Doctor>(doctorDto);
        public DoctorDto MapDoctorToDoctorDto(Doctor doctor) => _mapper.Map<Doctor, DoctorDto>(doctor);
        public Room MapRoomDtoToRoom(RoomDto roomDto) => _mapper.Map<RoomDto, Room>(roomDto);
        public RoomDto MapRoomToRoomDto(Room room) => _mapper.Map<Room, RoomDto>(room);
        public List<Appointment> MapAppointmentDtosToAppointmentsList(List<AppointmentDto> appointmentDtos) => _mapper.Map<List<AppointmentDto>,List<Appointment>>(appointmentDtos);
        public List<Doctor> MapDoctorDtosToDoctorsList(List<DoctorDto> doctorDtos) => _mapper.Map<List<DoctorDto>, List<Doctor>>(doctorDtos);
        public List<Patient> MapPatientDtosToPatientsList(List<PatientDto> patientDtos) => _mapper.Map<List<PatientDto>, List<Patient>>(patientDtos);
        public List<Room> MapRoomDtosToRoomsList(List<RoomDto> roomDtos) => _mapper.Map<List<RoomDto>, List<Room>>(roomDtos);
    }
}
