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
    public class PatientRepository:GenericRepository<Patient>,IPatientRepository
    {
        public PatientRepository(DoctorissimoContext dbContext, DbSet<Patient> entities) : base(dbContext, entities)
        {
        }
    }
}
