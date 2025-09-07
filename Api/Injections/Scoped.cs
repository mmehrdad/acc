using Acc.Infrastructure.Repositories.Accounts.Documents;

namespace Acc.Api.Injections
{
    public static class Scoped
    {
        public static void RegisterScopeds(this IServiceCollection services)
        {
            RegisterRepositories(services);
            ScopedUseCase.RegisterUseCases(services);
        }
        static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            //services.AddScoped<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
        }
    }
}
