using Acc.Api.Injections;
using Acc.Infrastructure.DBContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Acc.Api.Configuration
{
    public static class ApiDependencyContainer
    {

        public static IServiceCollection InjectDependency(this IServiceCollection services)
        {

            services.AddScoped<AccDbContext>();
            services.AddScoped(typeof(Lazy<>), typeof(Lazy<>));
            services.RegisterScopeds();

            services.InstallServicesInAssemblies();

            return services;

        }

    }
    internal class Lazier<T> : Lazy<T> where T : class
    {
        public Lazier(IServiceProvider provider)
            : base(() => provider.GetRequiredService<T>())
        {
        }
    }
    
}
