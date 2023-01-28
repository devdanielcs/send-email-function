using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using send_email_function.Domain;
using send_email_function.Infrastructure;
using send_email_function.Infrastructure.Interface;

namespace send_email_function.Application
{
    public class SendEmailFunction
    {
        public IMailClient MailClient { get; set; }
        public CreateMailMessage CreateMailMessage { get; }
        public SendEmailRequestValidator SendEmailRequestValidator { get; set; }

        public SendEmailFunction(
            IMailClient mailClient,
            CreateMailMessage createMailMessage,
            SendEmailRequestValidator sendEmailRequestValidator)
        {
            MailClient = mailClient ??
                throw new ArgumentNullException(nameof(mailClient));

            CreateMailMessage = createMailMessage ??
                throw new ArgumentNullException(nameof(createMailMessage));

            SendEmailRequestValidator = sendEmailRequestValidator ??
                throw new ArgumentNullException(nameof(sendEmailRequestValidator));
        }

        [FunctionName("SendEmail")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "email/send")] SendEmailRequest sendEmailRequest,
            ILogger log)
        {
            var validationResult = SendEmailRequestValidator.Validate(sendEmailRequest);
            if (!validationResult.IsValid)
                return new BadRequestObjectResult(
                    validationResult.Errors.Select(e => new
                    {
                        Field = e.PropertyName,
                        Error = e.ErrorMessage
                    }
                ));

            log.LogInformation("Send email trigger function start.");
            MailMessage mailMessage = CreateMailMessage.Create(sendEmailRequest);
            IActionResult result = MailClient.Send(mailMessage, log);

            return result;
        }
    }
}
