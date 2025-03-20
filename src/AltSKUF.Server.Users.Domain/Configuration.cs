using AltSKUF.Back.Users.Domain.Entity.Configuration;
using AltSKUF.Back.Users.Domain.Entity.Configuration.Smtp;

namespace AltSKUF.Back.Users.Domain
{
    public class Configuration
    {
        public static Configuration Singleton { get; set; } = new();

        public string DataBaseString { get; set; } = string.Empty;
        public string AuthenticationServiceAddress { get; set; } = string.Empty;

        public ServiceTokenOptions ServiceTokenOptions { get; set; } = new();
        public SmtpEmailOptions SmtpEmailOptions { get; set; } = new();
    }
}
