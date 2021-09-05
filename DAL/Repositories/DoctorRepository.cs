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

        public Task<List<Doctor>> GetAllDoctorsAsync() => GetAll().OrderBy(d =>d.FirstName).ToListAsync();
        public Task<Doctor> GetDoctorByIdAsyncTask(int? id) => GetByIdAsync(id);
        public Task CreateNewDoctorAsync(Doctor doctor) => CreateAsync(doctor);
        public Task DeleteDoctorAsync(int id) => DeleteAsync(id);
        public Task UpdateDoctorAsync(int id, Doctor doctor) => UpdateAsync(id, doctor);
        public bool CheckIfDoctorExists(int? id) => CheckIfExists(id);
        public  Task<List<Doctor>> GetDoctorsBySpecialtyAsync(DoctorSpecialty doctorSpecialty) => DbContext.Doctors
            .Select(d => d)
            .Where(d => d.Specialty == doctorSpecialty)
            .ToListAsync();
    }
}
