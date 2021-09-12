using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;
using DAL.Enums;
using DAL.Validation;

namespace DAL.Models
{
    public class Appointment :IEntity
    {
        public Appointment()
        {
            AppointmentStatus = AppointmentStatus.Available;
        }

        [Key]
        public int Id { get; set; }
        [DisplayName("Status")]
        public AppointmentStatus AppointmentStatus { get; set; }

        [DisplayName("Appointment time")]
        [DataType(DataType.DateTime)]
        [CheckDateInFuture(ErrorMessage = "Appointment date and time must be in the future.")]
        public DateTime AppointmentTime { get; set; }
        public int? PatientId { get; set; }
        public int DoctorId { get; set; }
        public int RoomId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Room Room { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendations { get; set; }
        public List<Prescription> Prescriptions { get; set; }
    }
}
