using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.IServices;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class PatientService :IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<PatientDTO>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllPatientsAsync();
        }

        public async Task<PatientDTO> GetPatientByIdAsync(int? id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }

        public Task AddNewPatientAsync(PatientDTO patientDto)
        {
            return _patientRepository.CreateNewPatientAsync(patientDto);
        }

        public Task DeletePatientAsync(int id)
        {
            return _patientRepository.DeletePatientAsync(id);
        }

        public Task UpdatePatientAsync(int id, PatientDTO patientDto)
        {
            return _patientRepository.UpdatePatientAsync(id, patientDto);
        }

        public bool CheckIfPatientExists(int? id)
        {
            return _patientRepository.CheckIfPatientExists(id);
        }

        public Task<bool> CheckIfPatientWIthEmailExists(string mail)
        {
            var patient =  _patientRepository.GetPatientEmailByEmail(mail);
            return default;
        }
    }
}
