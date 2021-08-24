using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models.ViewModels
{
    public class CreateAppointmentViewModel
    {
        [DisplayName("Patient name")]
        public List<Doctor> Doctors { get; set; }

        public Appointment Appointment { get; init; }
    }
}
