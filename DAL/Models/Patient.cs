using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities;

namespace DAL.Models
{
    public class Patient :IEntity
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        [Required]
        public string LastName { get; set; }
        [DisplayName("Date of birth")]
        //[Range(typeof(DateTime),"1/1/1000","8/12/2021",ErrorMessage = "Date is out of range")] 
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Mail address")]
        [RegularExpression(@"^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string MailAddress { get; set; }
        [Required]
        public string Address { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        [NotMapped]
        [DisplayName("Patient")]
        public string FullName => FirstName + " " + LastName;
    }
}
