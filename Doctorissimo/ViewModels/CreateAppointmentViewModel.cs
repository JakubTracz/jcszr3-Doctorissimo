using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace Doctorissimo.ViewModels
{
    public class CreateAppointmentViewModel:BaseViewModel
    {
        public List<Doctor> Doctors { get; set; }
        [Required(ErrorMessage = "Please select a doctor")]
        public int SelectedDoctorId { get; set; }
        [Required(ErrorMessage = "Please select a room")]
        public int SelectedRoomId { get; set; }
        public Appointment Appointment { get; init; }
        public List<Room> Rooms { get; set; }
    }
}
