using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Enums;

namespace DAL.Models.ViewModels
{
    public class AppointmentsListViewModel
    {
        public int Id { get; set; }
        [DisplayName("Status")]
        public AppointmentStatus AppointmentStatus { get; set; }

        [DisplayName("Appointment time")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentTime { get; set; }
        public string DoctorFullName { get; set; }
        public string PatientFullName { get; set; }
        public string Room { get; set; }
    }
}
