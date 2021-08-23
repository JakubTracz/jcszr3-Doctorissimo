using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DAL.Enums;

namespace DAL.Models.ViewModels
{
    public class BookAppointmentViewModel
    {
        public BookAppointmentViewModel()
        {
            Appointment.AppointmentStatus = AppointmentStatus.Booked;
        }
        [DisplayName("Patient name")]
        public int SelectedPatientId { get; set; }
        public List<Patient> Patients { get; set; }
        //private AppointmentStatus AppointmentStatus { get; }
        //public DateTime AppointmentTime { get; set; }
        //public string Doctor { get; set; }
        //public string Room { get; set; }
        public Appointment Appointment { get; set; }
    }
}
