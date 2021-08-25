using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Enums;
using DAL.Models;

namespace BLL.IServices
{
    public interface IDoctorService
    {
        public Task<List<Doctor>> GetAllDoctorsAsync();
        public Task<Doctor> GetDoctorByIdAsync(int? id);
        public Task AddNewDoctorAsync(Doctor doctor);
        public Task DeleteDoctorAsync(int id);
        public Task UpdateDoctorAsync(int id, Doctor doctor);
        public bool CheckIfDoctorExists(int? id);
        public Task<List<Doctor>> GetDoctorsBySpecialtyAsync(DoctorSpecialty doctorSpecialty);
    }
}
