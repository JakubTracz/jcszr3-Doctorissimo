using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Enums;

namespace DAL.Models.ViewModels
{
    public class AppointmentsListViewModel:BaseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Status")]
        public AppointmentStatus AppointmentStatus { get; set; }

        [DisplayName("Appointment time")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentTime { get; set; }
        [DisplayName("Doctor")]
        public string DoctorFullName { get; set; }
        public int? RoomId { get; set; }
        public int? PatientId { get; set; }
        [DisplayName("Patient")]
        public string PatientFullName { get; set; }
        [DisplayName("Room")]
        public string RoomName { get; set; }
    }
}
