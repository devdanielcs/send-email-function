namespace send_email_function.Modules
{
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public int Timeout { get; set; }
        public string EmailName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
