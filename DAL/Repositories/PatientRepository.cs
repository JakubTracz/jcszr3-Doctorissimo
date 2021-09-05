using System;
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

        public Task<Patient> GetPatientByIdAsync(int? id)
        {
            return GetByIdAsync(id);
        }

        public Task CreateNewPatientAsync(Patient patient)
        {
            return CreateAsync(patient);
        }

        public Task DeletePatientAsync(int id)
        {
            return DeleteAsync(id);
        }

        public Task UpdatePatientAsync(int id, Patient patient)
        {
            return UpdateAsync(id, patient);
        }

        public bool CheckIfPatientExists(int? id)
        {
            return CheckIfExists(id);
        }

        public async Task<bool> GetPatientEmailByEmail(string mail)
        {
            var result = await Entities.
                Where(patient => patient.MailAddress.ToUpper() == mail.ToUpper())
                .Select(patient => patient).ToListAsync();
            var aaa = result;
            return await Entities.AnyAsync(patient => patient.MailAddress== mail);
        }

        public Task<List<Patient>> GetAllPatientsAsync()
        {
            return GetAll().OrderBy(p => p.FirstName).ToListAsync();
        }
    }
}
