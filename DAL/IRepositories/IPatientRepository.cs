using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.IRepositories
{
    public interface IPatientRepository:IGenericRepository<Patient>
    {
        Task<List<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int? id);
        public Task CreateNewPatientAsync(Patient patient);
        public Task DeletePatientAsync(int id);
        public Task UpdatePatientAsync(int id,Patient patient);
        public bool CheckIfPatientExists(int? id);
        public Task<bool> GetPatientEmailByEmail(string mail);
    }
}
