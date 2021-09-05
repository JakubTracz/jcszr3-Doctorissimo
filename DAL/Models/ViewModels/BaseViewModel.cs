using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models.ViewModels
{
    public class BaseViewModel
    {
        public Doctor Doctor { get; set; }
        public int? DoctorId { get; set; }
    }
}
