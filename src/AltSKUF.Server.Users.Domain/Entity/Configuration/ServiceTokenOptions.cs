namespace AltSKUF.Back.Users.Domain.Entity.Configuration
{
    public class ServiceTokenOptions
    {
        public string Secret { get; set; } = string.Empty;
        public string ExpirationTimeFromMinutes { get; set; } = string.Empty;
    }
}
