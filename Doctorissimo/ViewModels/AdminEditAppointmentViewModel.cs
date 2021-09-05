using System.Collections.Generic;
using DAL.Models;

namespace Doctorissimo.ViewModels
{
    public class AdminEditAppointmentViewModel:BaseViewModel
    {
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public Patient Patient { get; set; }
        public Room Room { get; set; }
        public int? SelectedRoomId { get; set; }
        public Appointment Appointment { get; init; }
        public List<Room> Rooms { get; set; }
    }
}
