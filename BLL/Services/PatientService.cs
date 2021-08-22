using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        public Task<Patient> GetPatientByIdAsync(int? id)
        {
            return _patientRepository.GetByIdAsync(id);
        }

        public Task AddNewPatient(Patient patient)
        {
            return _patientRepository.CreateAsync(patient);
        }

        public Task DeletePatient(int id)
        {
            return _patientRepository.DeleteAsync(id);
        }

        public Task UpdatePatient(int id, Patient patient)
        {
            return _patientRepository.UpdateAsync(id, patient);
        }

        public bool CheckIfPatientExists(int? id)
        {
            return _patientRepository.CheckIfExists(id);
        }
    }
}
