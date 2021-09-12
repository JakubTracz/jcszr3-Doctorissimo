using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities;
using DAL.Validation;

namespace DAL.Models
{
    public class Patient :IEntity
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [DisplayName("Date of birth")]
        [CheckDateInPast(ErrorMessage = "Date of birth cannot be later than today.")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Mail address")]
        [RegularExpression(@"^[_a-zA-Z0-9-]+(.[a-zA-Z0-9-]+)@[A-Za-z0-9-]+(.[A-Za-z0-9-]+)*(.[A-Za-z]{2,4})$",ErrorMessage = "E-mail format is invalid.")]
        [Required(ErrorMessage = "E-mail address is required.")]
        public string MailAddress { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        [NotMapped]
        [DisplayName("Patient")]
        public string FullName => FirstName + " " + LastName;
    }
}
