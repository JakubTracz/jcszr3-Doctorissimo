using System.ComponentModel.DataAnnotations;

namespace DAL.Enums
{
    public enum AppointmentStatus
    {
        Available = 0,
        Booked = 1,
        Completed = 2,
        [Display(Name = "In progress")]
        InProgress = 3,
        
    }
}
