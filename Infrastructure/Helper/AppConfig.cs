using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Acc.Infrastructure.Helper
{
    public static class AppConfig
    {
        public static string GetConnectionString(string name)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: false)
                //.AddEnvironmentVariables()
                .Build();

            return configuration.GetConnectionString(name);
        }

        public static string GetSection(string section, string subSection)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: false)
                //.AddEnvironmentVariables()
                .Build();

            return configuration.GetSection(section)?.GetSection(subSection)?.Value;
        }
    }
}
