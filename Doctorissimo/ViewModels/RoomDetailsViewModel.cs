using System.Collections.Generic;
using DAL.Models;

namespace Doctorissimo.ViewModels
{
    public class RoomDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
