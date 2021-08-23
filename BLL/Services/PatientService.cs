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

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _patientRepository.GetAllPatientsAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int? id)
        {
            return await _patientRepository.GetPatientByIdAsyncTask(id);
        }

        public Task AddNewPatient(Patient patient)
        {
            return _patientRepository.CreateNewPatient(patient);
        }

        public Task DeletePatient(int id)
        {
            return _patientRepository.DeletePatient(id);
        }

        public Task UpdatePatient(int id, Patient patient)
        {
            return _patientRepository.UpdatePatient(id, patient);
        }

        public bool CheckIfPatientExists(int? id)
        {
            return _patientRepository.CheckIfPatientExists(id);
        }
    }
}
