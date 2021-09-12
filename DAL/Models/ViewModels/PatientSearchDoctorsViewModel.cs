using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Enums;

namespace DAL.Models.ViewModels
{
    public class PatientSearchDoctorsViewModel
    {
        public List<Doctor> Doctors { get; set; }
        [Display(Name = "Specialty")]
        public DoctorSpecialty DoctorSpecialty { get; set; }
    }
}
