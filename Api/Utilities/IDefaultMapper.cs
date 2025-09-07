using Acc.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Api.Utilities
{
    public interface IDefaultMapper : IScopedDependency
    {
        IQueryable<TDestination> FromSourceQueryToDestinationQuery<TSource, TDestination>(IQueryable<TSource> sourceQuery) where TSource : class;
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
            where TSource : class
            where TDestination : class;
        TDestination Map<TSource, TDestination>(TSource source) where TSource : class;
        TDestination Map<TDestination>(object source) where TDestination : class;
    }
}
