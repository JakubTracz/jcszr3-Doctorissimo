using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Models
{
    public class Prescription:IEntity
    {
        public int Id { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<Medication> Medications { get; set; }
        public string Comments { get; set; }
    }
}
