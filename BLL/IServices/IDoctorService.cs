using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Enums;
using DAL.Models;

namespace BLL.IServices
{
    public interface IDoctorService
    {
        public Task<List<DoctorDTO>> GetAllDoctorsAsync();
        public Task<DoctorDTO> GetDoctorByIdAsync(int? id);
        public Task AddNewDoctorAsync(DoctorDTO doctorDto);
        public Task DeleteDoctorAsync(int id);
        public Task UpdateDoctorAsync(int id, DoctorDTO doctorDto);
        public bool CheckIfDoctorExists(int? id);
        public Task<List<DoctorDTO>> GetDoctorsBySpecialtyAsync(DoctorSpecialty doctorSpecialty);
    }
}
