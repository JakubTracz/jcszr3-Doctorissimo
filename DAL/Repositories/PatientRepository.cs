using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {

        public PatientRepository(DoctorissimoContext dbContext) : base(dbContext)
        {
        }

        public Task<Patient> GetPatientByIdAsync(int? id) => GetByIdAsync(id);
        public Task CreateNewPatientAsync(Patient patient) => CreateAsync(patient);
        public Task DeletePatientAsync(int id) => DeleteAsync(id);
        public Task UpdatePatientAsync(int id, Patient patient) => UpdateAsync(id, patient);
        public bool CheckIfPatientExists(int? id) => CheckIfExists(id);
        public  Task<bool> CheckIfPatientWithProvidedEmailExists(string mail) => Entities.AnyAsync(patient => patient.MailAddress.ToUpper()== mail.ToUpper());
        public Task<List<Patient>> GetAllPatientsAsync() => GetAll().OrderBy(p => p.FirstName).ToListAsync();
    }
}
