using DAL.Data;
using DAL.IRepositories;
using DAL.Models;

namespace DAL.Repositories
{
    public class DoctorRepository:GenericRepository<Doctor>,IDoctorRepository
    {
        public DoctorRepository(DoctorissimoContext dbContext) : base(dbContext)
        {
        }
    }
}
