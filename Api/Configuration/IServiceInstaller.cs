using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Acc.Api.Configuration
{
    public interface IServiceInstaller
    {
        void InstallServices(IServiceCollection services, Assembly startupProjectAssembly);
    }
}
