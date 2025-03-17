using AltSKUF.Back.Users.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AltSKUF.Back.Users.Domain.Extensions
{
    public static class CheckExtensions
    {
        public static async Task<bool> CheckEmail(GeneralContext db,
            string email)
        {
            bool isUsing = false;

            await db.AuthMethods
                .ForEachAsync(_ =>
                {
                    if (_.EmailAuthMethod!.Email == email
                    || _.GoogleAuthMethod!.Email == email
                    || _.VKAuthMethod!.Email == email
                    || _.YandexAuthMethod!.Email == email)
                        isUsing = true;
                });

            return isUsing;
        }
    }
}
