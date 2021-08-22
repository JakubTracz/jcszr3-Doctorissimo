using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Models
{
    public class MedicalTest:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TestDateTime { get; set; }
        public int AppointmentId { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public string Operator { get; set; }
    }
}
