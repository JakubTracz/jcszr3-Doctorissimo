using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Enums;
using DAL.Models;

namespace DAL.IRepositories
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsyncTask(int? id);
        public Task CreateNewDoctorAsync(Doctor doctor);
        public Task DeleteDoctorAsync(int id);
        public Task UpdateDoctorAsync(int id,Doctor doctor);
        public bool CheckIfDoctorExists(int? id);
        public Task<List<Doctor>> GetDoctorsBySpecialtyAsync(DoctorSpecialty doctorSpecialty);
    }
}
