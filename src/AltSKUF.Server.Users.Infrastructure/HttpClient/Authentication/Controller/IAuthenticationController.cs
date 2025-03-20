using AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication.Entety;
using Refit;

namespace AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication.Controller
{
    public interface IAuthenticationController
    {
        //[Post("/Authentication/Keys/Create")]
        //Task<UserKeysResponce> CreateKeys(
        //[Query] Guid userId);
        [Get("/Tokens/Get")]
        Task<TokensResponce> GetUserTokensWithService(
            [Query] Guid userId);

        [Get("/Tokens/Refresh")]
        Task<TokensResponce> RefreshUserTokens();
    }
}
