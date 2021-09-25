using System.Collections.Generic;
using System.ComponentModel;
using BLL.DTO;

namespace Doctorissimo.ViewModels
{
    public class BookAppointmentViewModel
    {
        [DisplayName("Patient name")]
        public int SelectedPatientId { get; set; }
        public List<PatientDto> Patients { get; set; }
        public AppointmentDto Appointment { get; set; }
    }
}
