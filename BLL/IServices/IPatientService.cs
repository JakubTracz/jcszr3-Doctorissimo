using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.IServices
{
    public interface IPatientService
    {
        public Task<List<Patient>> GetAllPatientsAsync();
        public Task<Patient> GetPatientByIdAsync(int? id);
        public Task AddNewPatientAsync(Patient patient);
        public Task DeletePatientAsync(int id);
        public Task UpdatePatientAsync(int id, Patient patient);
        public bool CheckIfPatientExists(int? id);
    }
}
