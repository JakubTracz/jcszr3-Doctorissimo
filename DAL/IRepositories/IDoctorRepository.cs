using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;

namespace DAL.IRepositories
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
    }
}
