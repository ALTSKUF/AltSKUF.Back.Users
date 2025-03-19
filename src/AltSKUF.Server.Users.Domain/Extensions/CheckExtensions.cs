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

            await db.AuthMethods
                .ForEachAsync(_ =>
                {
                    List<AuthMethod> authMethods = [];
                    if (_.EmailAuthMethod != null) authMethods.Add(_.EmailAuthMethod);
                    if (_.GoogleAuthMethod != null) authMethods.Add(_.GoogleAuthMethod);
                    if (_.VKAuthMethod != null) authMethods.Add(_.VKAuthMethod);
                    if (_.YandexAuthMethod != null) authMethods.Add(_.YandexAuthMethod);

                    foreach (var authMethod in authMethods)
                    {
                        if (authMethod.Email == email)
                        {
                            isUsing = true;
                            break;
                        }
                    }
                });

            return isUsing;
        }
    }
}
