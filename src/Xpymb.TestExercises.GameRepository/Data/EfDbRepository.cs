using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xpymb.TestExercises.GameRepository.Data.Entities;

namespace Xpymb.TestExercises.GameRepository.Data
{
    public class EfDbRepository : IDbRepository
    {
        private readonly ApplicationDbContext _context;

        public EfDbRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IEntity
        {
            return _context.Set<T>().Where(selector).AsQueryable();
        }

        public IEnumerable<T> GetAll<T>() where T : class, IEntity
        {
            return _context.Set<T>().AsNoTracking().AsEnumerable();
        }

        public async Task<T> AddAsync<T>(T entity) where T : class, IEntity
        {
            entity.IsActive = true;
            entity.DateCreated = DateTime.Now;
            
            var result = await _context.Set<T>().AddAsync(entity);

            return result.Entity;
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class, IEntity
        {
            var result = await Task.Run(() => _context.Set<T>().Update(entity).Entity);

            return result;
        }

        public async Task<T> DeleteAsync<T>(Guid entityId) where T : class, IEntity
        {
            var entity = await Task.Run(() => 
                Get<T>(entity => entity.Id == entityId).AsNoTracking().FirstOrDefaultAsync());
            
            await Task.Run(() =>
            {
                if (entity != null) _context.Set<T>().Remove(entity);
            });

            return entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}