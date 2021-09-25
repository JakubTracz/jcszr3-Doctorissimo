using System.Collections.Generic;
using BLL.DTO;

namespace Doctorissimo.ViewModels
{
    public class AdminEditAppointmentViewModel
    {
        public List<DoctorDto> Doctors { get; set; }
        public List<PatientDto> Patients { get; set; }
        public PatientDto Patient { get; set; }
        public DoctorDto Doctor { get; set; }
        public RoomDto Room { get; set; }
        public int SelectedRoomId { get; set; }
        public AppointmentDto Appointment { get; init; }
        public List<RoomDto> Rooms { get; set; }
    }
}
