using MedicalCards.DAL.Repositories.Interfaces;
using MedicalCards.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCards.DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly AppContext _context;
        protected readonly DbSet<TEntity> set;
        protected Repository(AppContext context)
        {
            _context = context;   
            set = context.Set<TEntity>();
        }
        public async Task<TEntity> Create(TEntity item)
        {
            EntityEntry<TEntity> create = await set.AddAsync(item);
            await _context.SaveChangesAsync();
            return create.Entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            TEntity entry = await GetById(id);
            set.Remove(entry);
            await _context.SaveChangesAsync();
            return entry;
        }

        public void Delete(TEntity entry)
        {
            set.Remove(entry);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return await set.AsNoTracking().Where(predicate).ToArrayAsync();
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
