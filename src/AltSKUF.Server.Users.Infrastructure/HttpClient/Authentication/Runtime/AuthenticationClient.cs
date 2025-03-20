using AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication.Controller;
using Refit;

namespace AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication.Runtime
{
    public class AuthenticationClient(
        System.Net.Http.HttpClient httpClient) : IAuthenticationClient
    {
        public Uri? Uri => httpClient.BaseAddress;
        public System.Net.Http.HttpClient HttpClient => httpClient;

        public IAuthenticationController AuthenticationController { get; } = RestService.For<IAuthenticationController>(httpClient);

    }
}
