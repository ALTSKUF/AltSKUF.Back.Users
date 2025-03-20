namespace AltSKUF.Back.Users.Domain.Entity.Configuration.Smtp
{
    public class SmtpEmailOptions
    {
        public SmtpOptions SmtpOptions { get; set; } = new();
        public EmailOptions EmailOptions { get; set; } = new();
        public NetworkCredential NetworkCredential { get; set; } = new();
    }
}
