using System.Collections.Generic;

namespace DAL.Models.ViewModels
{
    public class CreateAppointmentViewModel:BaseViewModel
    {
        public List<Doctor> Doctors { get; set; }
        public int? SelectedDoctorId { get; set; }
        public int? SelectedRoomId { get; set; }
        public Appointment Appointment { get; init; }
        public List<Room> Rooms { get; set; }
    }
}
