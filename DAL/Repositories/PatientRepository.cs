using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Data;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PatientRepository:GenericRepository<Patient>,IPatientRepository
    {

        public PatientRepository(DoctorissimoContext dbContext) : base(dbContext)
        {
        }

        public Task<Patient> GetPatientByIdAsyncTask(int? id)
        {
            return GetByIdAsync(id);
        }

        public Task CreateNewPatient(Patient patient)
        {
            return CreateAsync(patient);
        }

        public Task DeletePatient(int id)
        {
            return DeleteAsync(id);
        }

        public Task UpdatePatient(int id, Patient patient)
        {
            return UpdateAsync(id, patient);
        }

        public bool CheckIfPatientExists(int? id)
        {
            return CheckIfExists(id);
        }

        public Task<List<Patient>> GetAllPatientsAsync()
        {
            return GetAll().ToListAsync();
        }
    }
}
