using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Enums;

namespace BLL.IServices
{
    public interface IDoctorService
    {
        public Task<List<DoctorDto>> GetAllDoctorsAsync();
        public Task<DoctorDto> GetDoctorByIdAsync(int? id);
        public Task AddNewDoctorAsync(DoctorDto doctorDto);
        public Task DeleteDoctorAsync(int id);
        public Task UpdateDoctorAsync(int id, DoctorDto doctorDto);
        public bool CheckIfDoctorExists(int? id);
        public Task<List<DoctorDto>> GetDoctorsBySpecialtyAsync(DoctorSpecialty doctorSpecialty);
    }
}
