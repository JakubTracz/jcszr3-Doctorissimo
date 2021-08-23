using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.IRepositories
{
    public interface IPatientRepository:IGenericRepository<Patient>
    {
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsyncTask(int? id);
        public Task CreateNewPatient(Patient patient);
        public Task DeletePatient(int id);
        public Task UpdatePatient(int id,Patient patient);
        public bool CheckIfPatientExists(int? id);
    }
}
