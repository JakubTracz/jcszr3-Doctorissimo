using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.IServices;
using DAL.Enums;
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

        public Task<List<DoctorDTO>> GetAllDoctorsAsync()
        {
            return _doctorRepository.GetAllDoctorsAsync();
        }

        public Task<DoctorDTO> GetDoctorByIdAsync(int? id)
        {
            return _doctorRepository.GetDoctorByIdAsyncTask(id);
        }

        public Task AddNewDoctorAsync(DoctorDTO doctorDto)
        {
            return _doctorRepository.CreateNewDoctorAsync(doctorDto);
        }

        public Task DeleteDoctorAsync(int id)
        {
            return _doctorRepository.DeleteDoctorAsync(id);
        }

        public Task UpdateDoctorAsync(int id, DoctorDTO doctorDto)
        {
            return _doctorRepository.UpdateDoctorAsync(id, doctorDto);
        }

        public bool CheckIfDoctorExists(int? id)
        {
            return _doctorRepository.CheckIfDoctorExists(id);
        }

        public Task<List<DoctorDTO>> GetDoctorsBySpecialtyAsync(DoctorSpecialty doctorSpecialty)
        {
            return _doctorRepository.GetDoctorsBySpecialtyAsync(doctorSpecialty);
        }

    }
}
