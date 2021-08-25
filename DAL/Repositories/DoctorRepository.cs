using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Enums;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DoctorRepository:GenericRepository<Doctor>,IDoctorRepository
    {
        public DoctorRepository(DoctorissimoContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return GetAll().ToListAsync();
        }

        public Task<Doctor> GetDoctorByIdAsyncTask(int? id)
        {
            return GetByIdAsync(id);
        }

        public Task CreateNewDoctorAsync(Doctor doctor)
        {
            return CreateAsync(doctor);
        }

        public Task DeleteDoctorAsync(int id)
        {
            return DeleteAsync(id);
        }

        public Task UpdateDoctorAsync(int id, Doctor doctor)
        {
            return UpdateAsync(id, doctor);
        }

        public bool CheckIfDoctorExists(int? id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Doctor>> GetDoctorsBySpecialtyAsync(DoctorSpecialty doctorSpecialty)
        {
            return await DbContext.Doctors.Select(d => d).Where(d => d.Specialty == doctorSpecialty).ToListAsync();
        }
    }
}
