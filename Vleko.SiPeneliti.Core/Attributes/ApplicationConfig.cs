namespace Vleko.Bayarind.Core.Attributes
{
    public class ApplicationConfig
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int TokenExpired { get; set; }
        public string AppUrl { get; set; }
        public string ApiUrl { get; set; }
        public string DefaultPassword { get; set; }
        public string WorkflowCode { get; set; }
    }
    public class EmailConfig
    {
        public string Smtp { get; set; }
        public int SmtpPort { get; set; }
        public string SenderMail { get; set; }
        public string Password { get; set; }
    }
    public class AttachmentMail
    {
        public Stream File { get; set; }
        public string Name { get; set; }
    }
}
