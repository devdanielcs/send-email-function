using System.Collections.Generic;

namespace send_email_function.Domain
{
    public class SendEmailRequest
    {
        public string Recipient { get; set; }
        public List<string> CCs { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool IsImportant { get; set; }
    }
}
