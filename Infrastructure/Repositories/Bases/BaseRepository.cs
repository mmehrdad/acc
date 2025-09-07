using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using Acc.Infrastructure.DBContexts;
using Acc.Core.Entities.Helper;

namespace Acc.Infrastructure.Repositories.Bases
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AccDbContext context;
        private bool _disposed;

        public BaseRepository(AccDbContext context) => this.context = context;

        public IQueryable<TEntity> GetAllAsNoTrackingNoGlobalFilter() => context.Set<TEntity>().AsNoTracking().IgnoreQueryFilters();
        public IQueryable<TEntity> GetAllAsNoTracking() => context.Set<TEntity>().AsNoTracking();
        public IQueryable<TEntity> GetAll() => context.Set<TEntity>();

        #region Asynchronous
        public virtual async Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.FromResult(context.Set<TEntity>().Where(predicate));
        }
        public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }
        public virtual async Task<TEntity> FindAsync(object id)
        {
            return await context.Set<TEntity>().FindAsync(new object[] { id });
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken token)
        {
            SetIdsAndZerosToNull(entity);
            var entityIdProp = typeof(TEntity).GetProperty("Id");
            var entityId = entityIdProp?.GetValue(entity) as string;

            if (entityIdProp != null)//&& string.IsNullOrEmpty(entityId)
            {
                entityId = IdGenerator.GenerateCustomId();
                entityIdProp.SetValue(entity, entityId);
            }

            // Loop over all ICollection<T> child properties
            var properties = typeof(TEntity).GetProperties()
                .Where(p => p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>));

            foreach (var prop in properties)
            {
                var children = prop.GetValue(entity) as IEnumerable<object>;
                if (children == null) continue;

                foreach (var child in children)
                {
                    // Set child's Id if exists and null
                    var childIdProp = child.GetType().GetProperty("Id");
                    if (childIdProp != null)// && string.IsNullOrEmpty(childIdProp.GetValue(child) as string)
                    {
                        childIdProp.SetValue(child, IdGenerator.GenerateCustomId());
                    }

                    // Set FK to parent if property named like: EntityNameId
                    //var fkProp = child.GetType().GetProperty(typeof(TEntity).Name + "Id");
                    //if (fkProp != null && entityId != null)
                    //{
                    //    fkProp.SetValue(child, entityId);
                    //}
                }
            }


            await context.Set<TEntity>().AddAsync(entity, token);
            return entity;
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return await Task.FromResult(entity);
        }
        public virtual async Task<TEntity> RemoveAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return await Task.FromResult(entity);
        }
        #endregion

        #region Synchronous
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }
        //public virtual TEntity FindOneAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return context.Set<TEntity>().Where(predicate).FirstOrDefault();
        //}
        //public virtual TEntity FindAsync(object id)
        //{
        //    return context.Set<TEntity>().Find(new object[] { id });
        //}
        public virtual TEntity Add(TEntity entity)
        {
            SetIdsAndZerosToNull(entity);
            var entityIdProp = typeof(TEntity).GetProperty("Id");
            var entityId = entityIdProp?.GetValue(entity) as string;

            if (entityIdProp != null)//&& string.IsNullOrEmpty(entityId)
            {
                entityId = IdGenerator.GenerateCustomId();
                entityIdProp.SetValue(entity, entityId);
            }

            // Loop over all ICollection<T> child properties
            var properties = typeof(TEntity).GetProperties()
                .Where(p => p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>));

            foreach (var prop in properties)
            {
                var children = prop.GetValue(entity) as IEnumerable<object>;
                if (children == null) continue;

                foreach (var child in children)
                {
                    // Set child's Id if exists and null
                    var childIdProp = child.GetType().GetProperty("Id");
                    if (childIdProp != null)//&& string.IsNullOrEmpty(childIdProp.GetValue(child) as string)
                    {
                        childIdProp.SetValue(child, IdGenerator.GenerateCustomId());
                    }

                    // Set FK to parent if property named like: EntityNameId
                    //var fkProp = child.GetType().GetProperty(typeof(TEntity).Name + "Id");
                    //if (fkProp != null && entityId != null)
                    //{
                    //    fkProp.SetValue(child, entityId);
                    //}
                }
            }

            context.Set<TEntity>().Add(entity);
            return entity;
        }
        public virtual TEntity Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return entity;
        }
        public virtual TEntity Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return entity;
        }

        public virtual IQueryable<TEntity> RemoveRange(IQueryable<TEntity> entity)
        {
            context.Set<TEntity>().RemoveRange(entity);
            return entity;
        }

        #endregion
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {

                var result = await context.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Concurrency_Exception");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SaveChanges()
        {
            try
            {

                var result = context.SaveChanges();

                return result;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Concurrency_Exception");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void SetState(EntityState entityState, TEntity entity)
        {
            context.Entry(entity).State = entityState;
        }


        ///==============================================================================
        private void SetIdsAndZerosToNull(TEntity entity)
        {
            if (entity == null) return;

            var properties = typeof(TEntity)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.CanRead && p.CanWrite);

            foreach (var property in properties)
            {
                // Skip navigation properties (collections/references)
                if (property.GetMethod.IsVirtual) continue;

                var value = property.GetValue(entity);

                // Check if property name contains "Id" (case-insensitive)
                bool isIdField = property.Name.Length >= 2 &&
                 property.Name.EndsWith("Id", StringComparison.Ordinal);

                // Check if value is 0 (for numeric types)
                bool isZero = IsZero(value);

                // Set to null if applicable
                if ((isIdField && isZero) && IsNullable(property.PropertyType))
                {
                    property.SetValue(entity, null);
                }
            }
        }

        private static bool IsZero(object value)
        {
            if (value == null) return false;

            switch (value)
            {
                case int i when i == 0:
                case long l when l == 0:
                case short s when s == 0:
                case decimal d when d == 0:
                case double db when db == 0:
                case float f when f == 0:
                case string ss when ss == "0":
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsNullable(Type type)
        {
            // Check if type is a reference type or Nullable<T>
            return !type.IsValueType || Nullable.GetUnderlyingType(type) != null;
        }
        ///
    }


}