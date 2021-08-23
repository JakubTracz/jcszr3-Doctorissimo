using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.IServices
{
    public interface IPatientService
    {
        public Task<List<Patient>> GetAllPatients();
        public Task<Patient> GetPatientByIdAsync(int? id);
        public Task AddNewPatient(Patient patient);
        public Task DeletePatient(int id);
        public Task UpdatePatient(int id, Patient patient);
        public bool CheckIfPatientExists(int? id);
    }
}
