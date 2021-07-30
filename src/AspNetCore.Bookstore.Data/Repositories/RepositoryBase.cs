using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.Bookstore.Data.Context;
using AspNetCore.Bookstore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Bookstore.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly BookstoreContext Db;

        public RepositoryBase(BookstoreContext context) =>
            Db = context;

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await Db.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> GetById(int? id) =>
            await Db.Set<TEntity>().FindAsync(id);
        
        public virtual async Task Add(TEntity obj)
        {
            Db.Add(obj);
            await Db.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            await Db.SaveChangesAsync();
        }

        public virtual async Task Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            await Db.SaveChangesAsync();
        }

        public void Dispose() =>
            Db.Dispose();
    }
}