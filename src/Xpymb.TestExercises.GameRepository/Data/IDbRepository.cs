using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xpymb.TestExercises.GameRepository.Data.Entities;

namespace Xpymb.TestExercises.GameRepository.Data
{
    public interface IDbRepository
    {
        IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IEntity;
        IEnumerable<T> GetAll<T>() where T : class, IEntity;

        Task<T> AddAsync<T>(T entity) where T : class, IEntity;

        Task<T> DeleteAsync<T>(Guid entityId) where T : class, IEntity;

        Task<int> SaveChangesAsync();
    }
}