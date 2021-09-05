using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Enums;
using DAL.Models;

namespace Doctorissimo.ViewModels
{
    public class PatientSearchDoctorsViewModel
    {
        public List<Doctor> Doctors { get; set; }
        [Display(Name = "Specialty")]
        public DoctorSpecialty DoctorSpecialty { get; set; }
    }
}
