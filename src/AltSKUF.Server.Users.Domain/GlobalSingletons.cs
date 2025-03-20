using AltSKUF.Back.Users.Domain.Extensions;

namespace AltSKUF.Back.Users.Domain
{
    public class GlobalSingletons
    {
        public static GlobalSingletons Singletons { get; set; } = new();

        public HttpClient AuthenricationClient { get; set; } = HttpClientExtensions.InitAuthenticationClient();
    }

    public class AuthHttpClient
    {
        public DateTime Expiration { get; set; } = DateTime.Now;
        public HttpClient AuthenricationClient { get; set; } = HttpClientExtensions.InitAuthenticationClient();
    }
}
