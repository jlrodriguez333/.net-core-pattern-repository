using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HCDirectory.Repository.Helpers;

namespace HCDirectory.Repository.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;
        private DbSet<TEntity> Dbset;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
            Dbset = Context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity obj)
        {            
            Context.Set<TEntity>().Add(obj);
            await Context.SaveChangesAsync();            
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Task.Run(() => Context.Set<TEntity>().Find(id));
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await Task.Run(() => Dbset.Where(where).FirstOrDefault<TEntity>());
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Task<TEntity> entity = GetByIdAsync(id);
            Context.Set<TEntity>().Remove(entity.Result);
            await Context.SaveChangesAsync();
        }    

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => Context.Set<TEntity>().ToList());
        }
        public void Add(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
            Context.SaveChanges();
        }

    }
}
