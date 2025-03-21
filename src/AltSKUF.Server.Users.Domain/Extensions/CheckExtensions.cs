using AltSKUF.Back.Users.Persistance;
using AltSKUF.Back.Users.Persistance.Entity.AuthMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AltSKUF.Back.Users.Domain.Extensions
{
    public static class CheckExtensions
    {
        public static async Task<bool> CheckEmail(GeneralContext db, string email)
        {
            bool isUsing = false;

            isUsing = await db.AuthMethods.AnyAsync(_ => 
                (_.EmailAuthMethod != null && _.EmailAuthMethod.Email == email) ||
                (_.GoogleAuthMethod != null && _.GoogleAuthMethod.Email == email) ||
                (_.YandexAuthMethod != null && _.YandexAuthMethod.Email == email) ||
                (_.VKAuthMethod != null && _.VKAuthMethod.Email == email));

            return isUsing;
        }
    }
}
