using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Gestion_Certif.Extensions
{
    public  static class ConfigurationExtension
    {
        public static IConfigurationBuilder AddCustomConfiguration(this IConfigurationBuilder builder, IWebHostEnvironment env)
        {
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                   .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables();

            return builder;
        }

    }
}
