
using System.Security.Cryptography;
using AltSKUF.Back.Users.Domain.Extensions;
using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions;
using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.NotFoundExceptions;
using Microsoft.Extensions.Caching.Memory;

namespace AltSKUF.Back.Users.Domain.Services.Runtime
{
    public class VerifyService(
        IMemoryCache memoryCache) : IVerifyService
    {
        public async Task RefreshVerifyCode(Guid userId, string email)
        {
            if (!memoryCache.TryGetValue(userId, out var _))
                throw new NotFoundException("last_user_code");
            memoryCache.Remove(userId);

            var code = GenerateAndSetCode(userId);
            await SmtpExtensions.Send(new()
            {
                Body = code,
                RecipientEmail = email,
                Subject = "code"
            });
        }

        public async Task SendVerifyMessage(Guid userId, string email)
        {
            if (memoryCache.TryGetValue(userId, out var _))
                throw new IsAvalaibleExcepion("user_code");

            var code = GenerateAndSetCode(userId);
            await SmtpExtensions.Send(new()
            {
                Body = code,
                RecipientEmail = email,
                Subject = "code"
            });
        }

        public bool VerifyUser(Guid userId, string code)
        {
            if (memoryCache.TryGetValue(userId, out string? verifyCode))
            {
                return code == verifyCode;
            }
            throw new NotFoundException("user_code");
        }

        private string GenerateAndSetCode(Guid userId)
        {
            string code = RandomNumberGenerator.GetInt32(99999).ToString("D5");

            memoryCache.Set(userId, code, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

            return code;
        }
    }
}
