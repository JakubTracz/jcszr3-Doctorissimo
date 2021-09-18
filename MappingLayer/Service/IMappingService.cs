using System.Collections.Generic;
using BLL.DTO;
using DAL.Models;

namespace MappingLayer.Service
{
    public interface IMappingService
    {
        public Appointment MapAppointmentDtoToAppointment(AppointmentDto appointmentDto);
        public AppointmentDto MapAppointmentToAppointmentDto(Appointment appointment);
        public Patient MapPatientDtoToPatient(PatientDto patientDto);
        public PatientDto MapPatientToPatientDto(Patient patient);
        public Doctor MapDoctorDtoToDoctor(DoctorDto doctorDto);
        public DoctorDto MapDoctorToDoctorDto(Doctor doctor);
        public Room MapRoomDtoToRoom(RoomDto roomDto);
        public RoomDto MapRoomToRoomDto(Room room);
        public List<Appointment> MapAppointmentDtosToAppointmentsList(List<AppointmentDto> appointmentDtos);
        public List<Doctor> MapDoctorDtosToDoctorsList(List<DoctorDto> doctorDtos);
        public List<Patient> MapPatientDtosToPatientsList(List<PatientDto> doctorDtos);
        public List<Room> MapRoomDtosToRoomsList(List<RoomDto> roomDtos);
        
    }
}
