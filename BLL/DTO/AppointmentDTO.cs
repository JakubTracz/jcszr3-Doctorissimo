using System;
using DAL.Enums;

namespace BLL.DTO
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public DateTime AppointmentTime { get; set; }
        public PatientDto PatientDto { get; set; }
        public DoctorDto DoctorDto { get; set; }
        public RoomDto RoomDto { get; set; }
        public int RoomId { get; set; }
    }
}
