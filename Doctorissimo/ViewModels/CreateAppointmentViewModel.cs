using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BLL.DTO;

namespace Doctorissimo.ViewModels
{
    public class CreateAppointmentViewModel
    {
        public List<DoctorDto> Doctors { get; set; }
        [Required(ErrorMessage = "Please select a doctor")]
        public int SelectedDoctorId { get; set; }
        [Required(ErrorMessage = "Please select a room")]
        public int SelectedRoomId { get; set; }
        public AppointmentDto Appointment { get; init; }
        public List<RoomDto> Rooms { get; set; }
    }
}
