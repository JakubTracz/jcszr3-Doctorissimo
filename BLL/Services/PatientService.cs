using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.IServices;
using DAL.IRepositories;
using DAL.Models;

namespace BLL.Services
{
    public class PatientService :IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllPatientsAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int? id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }

        public Task AddNewPatientAsync(Patient patient)
        {
            return _patientRepository.CreateNewPatientAsync(patient);
        }

        public Task DeletePatientAsync(int id)
        {
            return _patientRepository.DeletePatientAsync(id);
        }

        public Task UpdatePatientAsync(int id, Patient patient)
        {
            return _patientRepository.UpdatePatientAsync(id, patient);
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
