using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace BLL.DTO
{
    public class MedicalTestDTO
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
