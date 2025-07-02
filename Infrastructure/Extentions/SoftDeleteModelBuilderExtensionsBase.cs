using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Acc.Core.Entities.Interfaces;

namespace Acc.Infrastructure.Extensions
{
    public static class SoftDeleteModelBuilderExtensionsBase
    {
        public static ModelBuilder ApplySoftDeleteQueryFilter(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                //if (!typeof(ISoftEntity).IsAssignableFrom(entityType.ClrType))
                //    continue;

                //var param = Expression.Parameter(entityType.ClrType, "entity");
                //var prop = Expression.PropertyOrField(param, nameof(ISoftEntity.IsDeleted));
                //var entityNotDeleted = Expression.Lambda(Expression.Equal(prop, Expression.Constant(false)), param);
                // entityType.SetQueryFilter(entityNotDeleted);

                var clrType = entityType.ClrType;

                if (!typeof(ISoftEntity).IsAssignableFrom(clrType))
                    continue;

                var parameter = Expression.Parameter(clrType, "e");
                var property = Expression.Property(parameter, nameof(ISoftEntity.IsDeleted));
                var isDeletedFalse = Expression.NotEqual(property, Expression.Constant(true, typeof(bool?)));
                
                //Expression.Equal(property, Expression.Constant(false));

                var lambda = Expression.Lambda(isDeletedFalse, parameter);

                entityType.SetQueryFilter(lambda);

               
            }

            return modelBuilder;
        }
    }
}