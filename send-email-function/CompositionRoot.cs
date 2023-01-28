using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using send_email_function.Modules;

namespace send_email_function
{
    public static class CompositionRoot
    {
        public static void ConfigureServices(
            IServiceCollection services)
        {
            IConfiguration configurations = GetConfigurations();

            services.AddSingleton(configurations);
            services.AddInjections(configurations);
        }

        private static IConfiguration GetConfigurations()
        {
            string actualRoot = Directory.GetCurrentDirectory();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(actualRoot)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }
    }
}
