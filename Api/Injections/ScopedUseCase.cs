using Acc.Application.Services.Accounts.Documents.CreateUseCase;
using Acc.Application.Services.Accounts.Documents.GetUseCase;
using Acc.Application.Services.Documents.Documents.CreateUseCase;
using Acc.Infrastructure.Helper;
using AutoMapper;

namespace Acc.Api.Injections
{
    public static class ScopedUseCase
    {
        internal static void RegisterUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUserInformationProvider, UserInformationProvider>();
            services.AddScoped<IMapper, Mapper>();
            // services.AddScoped<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();


            services.AddScoped<IDocumentCreateUseCase, DocumentCreateUseCase>();
            services.AddScoped<IDocumentGetUseCase, DocumentGetUseCase>();
        }
    }
}
