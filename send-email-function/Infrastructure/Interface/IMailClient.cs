using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace send_email_function.Infrastructure.Interface
{
    public interface IMailClient
    {
        IActionResult Send(MailMessage mailMessage, ILogger log);
    }
}
