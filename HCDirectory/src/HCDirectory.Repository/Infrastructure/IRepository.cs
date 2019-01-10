using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HCDirectory.Repository.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);       
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetByIdAsync(int id);       
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task DeleteAsync(int id);
        void Add(TEntity obj);
      
    }
}
