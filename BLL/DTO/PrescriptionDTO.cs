using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<MedicationDto> Medications { get; set; }
        public string Comments { get; set; }
    }
}
