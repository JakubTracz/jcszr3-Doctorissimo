using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Enums;

namespace DAL.Models.ViewModels
{
    public class BookAppointmentViewModel
    {
        //modele DTO
        [DisplayName("Patient name")]
        public int SelectedPatientId { get; set; }
        //[Required()]
        public string selectedPatientMail { get; set; }
        public List<Patient> Patients { get; set; }
        public Appointment Appointment { get; set; }
    }
}
