using DAL.Models;

namespace Doctorissimo.ViewModels
{
    public class BaseViewModel
    {
        public Doctor Doctor { get; set; }
        public int? DoctorId { get; set; }
    }
}
