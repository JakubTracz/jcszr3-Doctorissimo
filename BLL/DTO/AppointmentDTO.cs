using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Enums;
using DAL.Validation;

namespace BLL.DTO
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        [DisplayName("Appointment status")]
        public AppointmentStatus AppointmentStatus { get; set; }
        [DisplayName("Appointment time")]
        [DataType(DataType.DateTime)]
        [CheckDateInFuture(ErrorMessage = "Appointment date and time must be in the future.")]
        public DateTime AppointmentTime { get; set; }
        public PatientDto PatientDto { get; set; }
        public DoctorDto DoctorDto { get; set; }
        public RoomDto RoomDto { get; set; }
        public int? RoomId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
    }
}
