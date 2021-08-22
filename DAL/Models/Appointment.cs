using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Models
{
    public class Appointment :IEntity
    {
        public int Id { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Room { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendations { get; set; }
        public List<Prescription> Prescriptions { get; set; }
    }
}
