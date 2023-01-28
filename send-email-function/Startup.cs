using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(send_email_function.Startup))]
namespace send_email_function
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(
            IFunctionsHostBuilder builder)
        {
            CompositionRoot.ConfigureServices(builder.Services);
        }
    }
}
