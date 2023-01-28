using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using send_email_function.Modules;
using send_email_function.Infrastructure.Interface;

namespace send_email_function.Infrastructure
{
    public class MailClient : IMailClient
    {
        public SmtpClient SmtpClient { get; }
        public SmtpConfiguration SmtpConfiguration { get; }

        public MailClient(
            IOptions<SmtpConfiguration> smtpConfiguration)
        {
            SmtpClient = new();

            SmtpConfiguration = smtpConfiguration?.Value ??
                throw new ArgumentNullException(nameof(smtpConfiguration));
        }

        public IActionResult Send(
            MailMessage mailMessage,
            ILogger log)
        {
            try
            {
                BuildSmtpClient();

                mailMessage.From = new MailAddress(
                    SmtpConfiguration.Email,
                    SmtpConfiguration.EmailName
                );

                SmtpClient.Send(mailMessage);

                log.LogInformation("Message Sent Succesfully.");
                return new OkResult();
            }
            catch(Exception e)
            {
                log.LogError("Error Sending Message. Exception: " + e);
                throw;
            }
        }

        private void BuildSmtpClient()
        {
            SmtpClient.Host = SmtpConfiguration.Host;
            SmtpClient.Port = SmtpConfiguration.Port;
            SmtpClient.EnableSsl = SmtpConfiguration.EnableSsl;
            SmtpClient.Timeout = SmtpConfiguration.Timeout;
            SmtpClient.UseDefaultCredentials = SmtpConfiguration.UseDefaultCredentials;
            SmtpClient.Credentials = new NetworkCredential(
                SmtpConfiguration.Email,
                SmtpConfiguration.Password
            );
        }
    }
}
