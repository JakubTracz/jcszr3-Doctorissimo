using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities;
using DAL.Enums;

namespace BLL.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DoctorSpecialty Specialty { get; set; }
        public string FullName => FirstName + " " + LastName;

    }
}
