using AltSKUF.Back.RestClient.Authentication.Entety;

namespace AltSKUF.Back.Users.Infrastructure.Entity.Responce
{
    public class AuthorizationUserResponce : UserResponce
    {
        public TokensResponce Tokens { get; set; } = new();
    }
}
