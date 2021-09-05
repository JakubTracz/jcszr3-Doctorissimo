using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.IServices
{
    public interface IPatientService
    {
        public Task<List<PatientDto>> GetAllPatientsAsync();
        public Task<PatientDto> GetPatientByIdAsync(int? id);
        public Task AddNewPatientAsync(PatientDto patientDto);
        public Task DeletePatientAsync(int id);
        public Task UpdatePatientAsync(int id, PatientDto patientDto);
        public bool CheckIfPatientExists(int? id);
        public Task<bool> CheckIfPatientWIthEmailExists(string mail);
    }
}
