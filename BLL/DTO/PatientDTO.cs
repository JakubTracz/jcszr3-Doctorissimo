using System;

namespace BLL.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MailAddress { get; set; }
        public string Address { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}
