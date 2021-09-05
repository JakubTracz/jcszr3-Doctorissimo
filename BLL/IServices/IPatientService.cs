using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Models;

namespace BLL.IServices
{
    public interface IPatientService
    {
        public Task<List<PatientDTO>> GetAllPatientsAsync();
        public Task<PatientDTO> GetPatientByIdAsync(int? id);
        public Task AddNewPatientAsync(PatientDTO patientDto);
        public Task DeletePatientAsync(int id);
        public Task UpdatePatientAsync(int id, PatientDTO patientDto);
        public bool CheckIfPatientExists(int? id);
        public Task<bool> CheckIfPatientWIthEmailExists(string mail);
    }
}
