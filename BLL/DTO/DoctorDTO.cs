using DAL.Enums;

namespace BLL.DTO
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DoctorSpecialty Specialty { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}
