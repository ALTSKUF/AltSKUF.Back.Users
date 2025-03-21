using System.Net;
using System.Net.Mail;

namespace AltSKUF.Back.Users.Domain.Extensions
{
    public static class SmtpExtensions
    {
        public static async Task Send(SendSmtpOptions options)
        {
            MailAddress sender = new(
                Configuration.Singleton.SmtpEmailOptions.EmailOptions.Address,
                Configuration.Singleton.SmtpEmailOptions.EmailOptions.DisplayName);

            MailAddress recipient = new(options.RecipientEmail);

            MailMessage message = new(sender, recipient)
            {
                Body = options.Body,
                Subject = options.Subject,
            };

            SmtpClient smtpClient = new(
                host: Configuration.Singleton.SmtpEmailOptions.SmtpOptions.Host,
                port: int.Parse(Configuration.Singleton.SmtpEmailOptions.SmtpOptions.Port))
            {
                Credentials = new NetworkCredential(
                    Configuration.Singleton.SmtpEmailOptions.NetworkCredential.UserName,
                    Configuration.Singleton.SmtpEmailOptions.NetworkCredential.Password),
                EnableSsl = true
            };

            try { await smtpClient.SendMailAsync(message); }
            catch { throw new Extensions.CustomExceptions.BadRequestExceptions.SmtpException(); }
        }
    }

    public class SendSmtpOptions
    {
        public string Body { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string RecipientEmail { get; set; } = string.Empty;
    }
}