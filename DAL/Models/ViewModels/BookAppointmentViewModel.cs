using System.Collections.Generic;
using System.ComponentModel;
using DAL.Enums;

namespace DAL.Models.ViewModels
{
    public class BookAppointmentViewModel
    {
        public BookAppointmentViewModel(Appointment appointment)
        {
            Appointment = appointment;
        }
        [DisplayName("Patient name")]
        public int SelectedPatientId { get; set; }
        public List<Patient> Patients { get; set; }
        public Appointment Appointment { get; init; }
    }
}
