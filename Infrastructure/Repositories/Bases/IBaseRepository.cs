using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Infrastructure.Repositories.Bases
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> GetAllAsNoTrackingNoGlobalFilter();
        IQueryable<TEntity> GetAllAsNoTracking();
        IQueryable<TEntity> GetAll();

        #region Asynchronous
        Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(object id);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken token);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> RemoveAsync(TEntity model);
        #endregion

        #region Synchronous
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        // TEntity FindOneAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity model);
        IQueryable<TEntity> RemoveRange(IQueryable<TEntity> entity);
        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
        void SetState(EntityState entityState, TEntity entity);
    }
}
