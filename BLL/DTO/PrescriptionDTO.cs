using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace BLL.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<MedicationDTO> Medications { get; set; }
        public string Comments { get; set; }
    }
}
