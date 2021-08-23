using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity,new()
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int? id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(int id, TEntity entity);
        Task DeleteAsync(int id);
        public bool CheckIfExists(int? id);
    }
}
