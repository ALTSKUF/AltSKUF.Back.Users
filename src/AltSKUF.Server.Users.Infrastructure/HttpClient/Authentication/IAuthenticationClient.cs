using AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication.Controller;

namespace AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication
{
    public interface IAuthenticationClient
    {
        public Uri? Uri { get; }
        public System.Net.Http.HttpClient HttpClient { get; }

        public IAuthenticationController AuthenticationController { get; }
    }
}
