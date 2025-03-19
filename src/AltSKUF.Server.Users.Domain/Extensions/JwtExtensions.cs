using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions;
using Microsoft.IdentityModel.Tokens;

namespace AltSKUF.Back.Users.Domain.Extensions
{
    public static class JwtExtensions
    {
        public static string GetServicesToken()
        {
            DateTime now = DateTime.Now;
            DateTime expirationTime = now.Add(
                TimeSpan.FromMinutes(
                    int.Parse(Configuration.Singleton.ServiceTokenOptions.ExpirationTimeFromMinutes)));
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(Configuration.Singleton.ServiceTokenOptions.Secret));

            var jwt = new JwtSecurityToken(
            issuer: "AltSKUF.Back",
            audience: "AltSKUF.Back",
            claims: [],
            expires: expirationTime,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha384));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public static Guid GetUserId(this IEnumerable<Claim> claims)
        {
            var strUserId = claims.FirstOrDefault(_ => _.Type == "userId")
                ?? throw new BrokenTokenException();

            return Guid.Parse(strUserId.Value);
        }
    }
}
