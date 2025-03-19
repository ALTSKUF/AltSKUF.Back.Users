using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AltSKUF.Back.Users.Domain.Extensions
{
    public static class HttpClientExtensions
    {
        public static HttpClient InitAuthenticationClient()
        {
            var token = JwtExtensions.GetServicesToken();

            var client = new HttpClient()
            {
                BaseAddress =
                    new(Configuration.Singleton.AuthenticationServiceAddress),
            };
            client.DefaultRequestHeaders.Authorization =
                new("Bearer", token);

            return client;
        }
    }
}
