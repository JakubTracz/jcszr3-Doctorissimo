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
        protected readonly DoctorissimoContext _dbContext;
        protected readonly DbSet<TEntity> _entities;

        protected GenericRepository(DoctorissimoContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(int? id)
        {
            return await _entities.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TEntity entity)
        {
            _entities.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public bool CheckIfExists(int? id)
        {
            return  _entities.Any(e => e.Id == id);
        }
    }
}
