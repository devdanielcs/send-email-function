using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using send_email_function.Infrastructure;
using send_email_function.Infrastructure.Interface;

namespace send_email_function.Modules
{
    public static class FunctionModule
    {
        public static IServiceCollection AddInjections(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<SmtpConfiguration>(configuration.GetSection("SmtpConfiguration"));
            services.AddScoped<IMailClient, MailClient>();
            services.AddScoped<SendEmailRequestValidator>();
            services.AddScoped<CreateMailMessage>();

            return services;
        }
    }
}
