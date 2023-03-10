using Data_acccess_layer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> set;
        protected Repository(DbContext context)
        {
            _context = context;   
            set = context.Set<TEntity>();
        }
        public async Task<TEntity> Create(TEntity item)
        {
            EntityEntry<TEntity> create = await set.AddAsync(item);
            return create.Entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            TEntity entry = await GetById(id);
            set.Remove(entry);
            await _context.SaveChangesAsync();
            return entry;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllByPredicate(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await set.AsNoTracking().ToArrayAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await set.FindAsync(id);
        }

        public async Task<TEntity> Update(TEntity item)
        {
            EntityEntry<TEntity> update = set.Update(item);
            await _context.SaveChangesAsync();
            return update.Entity;
        }
    }
}
