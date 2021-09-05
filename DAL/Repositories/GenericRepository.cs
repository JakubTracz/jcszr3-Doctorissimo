using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Entities;
using DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly DoctorissimoContext DbContext;
        protected readonly DbSet<TEntity> Entities;
        protected GenericRepository(DoctorissimoContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll() => Entities.AsNoTracking();
        public async Task<TEntity> GetByIdAsync(int? id) => await Entities.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        public async Task CreateAsync(TEntity entity)
        {
            await Entities.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TEntity entity)
        {
            Entities.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            Entities.Remove(entity);
            await DbContext.SaveChangesAsync();
        }
        public bool CheckIfExists(int? id) => Entities.Any(e => e.Id == id);
    }
}
