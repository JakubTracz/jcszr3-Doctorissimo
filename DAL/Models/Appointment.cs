using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;
using DAL.Enums;

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
        public DateTime AppointmentTime { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public string Room { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendations { get; set; }
        public List<Prescription> Prescriptions { get; set; }
    }
}
