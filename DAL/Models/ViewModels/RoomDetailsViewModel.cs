using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models.ViewModels
{
    public class RoomDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
