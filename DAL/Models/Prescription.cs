using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace DAL.Models
{
    public class Prescription:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        [DisplayName("Date issued")]
        public DateTime DateIssued { get; set; }
        [DisplayName("Expiration date")]
        public DateTime ExpiryDate { get; set; }
        public List<Medication> Medications { get; set; }
        public string Comments { get; set; }
    }
}
