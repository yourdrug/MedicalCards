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
            //_context.SaveChanges();
            return create.Entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            try
            {
                TEntity entry = await GetById(id);
                set.Remove(entry);
                await _context.SaveChangesAsync();
                return entry;
            }

            catch(Exception)
            {
                throw new Exception("Incorrect deleting");
            }
            
        }

        public void Delete(TEntity entry)
        {
            if (entry == null)
            {
                throw new Exception("No object");
            }

            else
            {
                set.Remove(entry);
                _context.SaveChanges();
            }
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return await set.Where(predicate).ToArrayAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await set.ToArrayAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            var temp = await set.FindAsync(id);
            if (temp == null)
            {
                throw new Exception("No object by this id");
            }
            else 
            {
                return temp;
            }

        }

        public async Task<TEntity> Update(TEntity item)
        {
            if(item == null)
            {
                throw new Exception("Incorrect object to update");
            }

            else
            {
                EntityEntry<TEntity> update = set.Update(item);
                await _context.SaveChangesAsync();
                return update.Entity;
            }
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
