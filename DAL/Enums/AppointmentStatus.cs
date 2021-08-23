using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Enums
{
    public enum AppointmentStatus
    {
        Available = 0,
        Booked = 1,
        [Display(Name = "In progress")]
        InProgress = 2,
        Completed = 3,
    }
}
