namespace AltSKUF.Back.Users
{
    public class Configuration
    {
        public static Configuration Singleton { get; set; } = new();

        public string DataBaseString { get; set; } = "Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=wr3241rt";
    }
}
