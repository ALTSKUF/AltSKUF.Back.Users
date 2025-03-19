namespace AltSKUF.Back.Users.Domain
{
    public class Configuration
    {
        public static Configuration Singleton { get; set; } = new();

        public string DataBaseString { get; set; } = string.Empty;
        public string AuthenticationServiceAddress { get; set; } = string.Empty;

        public ServiceTokenOptions ServiceTokenOptions { get; set; } = new();
    }

    public class ServiceTokenOptions
    {
        public string Secret { get; set; } = string.Empty;
        public string ExpirationTimeFromMinutes { get; set; } = string.Empty;
    }
}
