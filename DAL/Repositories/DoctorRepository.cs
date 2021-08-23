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
    public class DoctorRepository:GenericRepository<Doctor>,IDoctorRepository
    {
        public DoctorRepository(DoctorissimoContext dbContext) : base(dbContext)
        {
        }
    }
}
