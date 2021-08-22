using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.IServices
{
    public interface IPatientService
    {
        public IQueryable<Patient> GetAllPatients();
        public Task<Patient> GetPatientByIdAsync(int? id);
        public Task AddNewPatient(Patient patient);
        public Task DeletePatient(int id);
        public Task UpdatePatient(int id,Patient patient);
        public bool CheckIfPatientExists(int? id);
    }
}
