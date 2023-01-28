using System.Net.Mail;
using send_email_function.Domain;

namespace send_email_function.Infrastructure
{
    public class CreateMailMessage
    {
        public MailMessage MailMessage { get; }

        public CreateMailMessage()
        {
            MailMessage = new();
        }

        public MailMessage Create(
            SendEmailRequest sendEmailRequest)
        {
            MailMessage.To.Add(sendEmailRequest.Recipient);
            MailMessage.Subject = sendEmailRequest.Subject;
            MailMessage.Body = sendEmailRequest.Message;
            MailMessage.IsBodyHtml = false;

            foreach (string cc in sendEmailRequest.CCs)
            {
                MailMessage.CC.Add(cc);
            }

            if (sendEmailRequest.IsImportant)
            {
                MailMessage.Priority = MailPriority.High;
            }

            return MailMessage;
        }
    }
}
