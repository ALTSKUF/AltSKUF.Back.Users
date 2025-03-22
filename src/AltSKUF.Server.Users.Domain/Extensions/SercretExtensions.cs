using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AltSKUF.Back.Users.Domain.Extensions
{
    public static class SercretExtensions
    {
        public static SymmetricSecurityKey? AccessTokenSecret { get; private set; }
        public static SymmetricSecurityKey? PreviousAccessTokenSecret { get; private set; }

        public static void UpdateAccessSecret(string secret)
        {
            var key = ToSymmetricSecurityKey(secret);
            if (PreviousAccessTokenSecret == null)
            {
                PreviousAccessTokenSecret = key;
                AccessTokenSecret = key;
            }
            else
            {
                PreviousAccessTokenSecret = AccessTokenSecret;
                AccessTokenSecret = key;
            }
        }

        private static SymmetricSecurityKey ToSymmetricSecurityKey(this string secret)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        }
    }
}