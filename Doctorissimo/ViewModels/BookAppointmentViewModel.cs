using System.Collections.Generic;
using System.ComponentModel;
using DAL.Models;

namespace Doctorissimo.ViewModels
{
    public class BookAppointmentViewModel:BaseViewModel
    {
        //modele DTO
        [DisplayName("Patient name")]
        public int SelectedPatientId { get; set; }
        public List<Patient> Patients { get; set; }
        public Appointment Appointment { get; set; }
        public Room Room { get; set; }
    }
}
