using AltSKUF.Back.Users.Domain.Extensions;

namespace AltSKUF.Back.Users.Domain
{
    public class GlobalSingletons
    {
        public static GlobalSingletons Singletons { get; set; } = new();

        public HttpClient AuthenricationClient { get; set; } = HttpClientExtensions.InitAuthenticationClient();
    }
}
