using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.IServices;
using DAL.IRepositories;
using DAL.Models;

namespace BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return _doctorRepository.GetAllDoctorsAsync();
        }

        public Task<Doctor> GetDoctorByIdAsync(int? id)
        {
            return _doctorRepository.GetDoctorByIdAsyncTask(id);
        }

        public Task AddNewDoctorAsync(Doctor doctor)
        {
            return _doctorRepository.CreateNewDoctorAsync(doctor);
        }

        public Task DeleteDoctorAsync(int id)
        {
            return _doctorRepository.DeleteDoctorAsync(id);
        }

        public Task UpdateDoctorAsync(int id, Doctor doctor)
        {
            return _doctorRepository.UpdateDoctorAsync(id, doctor);
        }

        public bool CheckIfDoctorExists(int? id)
        {
            return _doctorRepository.CheckIfDoctorExists(id);
        }
    }
}
