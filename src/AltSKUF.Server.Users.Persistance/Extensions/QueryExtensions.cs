using AltSKUF.Back.Users.Persistance.Entity;
using Microsoft.EntityFrameworkCore;

namespace AltSKUF.Back.Users.Persistance.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<User> IncludingUserQuery(this IQueryable<User> query,
            List<UserComponents> userComponents)
        {
            userComponents = userComponents
                .Distinct().ToList();

            foreach (var component in userComponents)
            {
                switch (component)
                {
                    case UserComponents.Inform:
                        query = query.Include(_ => _.UserInform);
                        break;
                    case UserComponents.Details:
                        query = query.Include(_ => _.UserDetails);
                        break;
                    case UserComponents.EmailAuth:
                        query = query.Include(_ => _.UserAuthMethods)
                            .ThenInclude(_ => _.EmailAuthMethod);
                        break;
                    case UserComponents.GoogleAuht:
                        query = query.Include(_ => _.UserAuthMethods)
                            .ThenInclude(_ => _.GoogleAuthMethod);
                        break;
                    case UserComponents.YandexAuth:
                        query = query.Include(_ => _.UserAuthMethods)
                            .ThenInclude(_ => _.YandexAuthMethod);
                        break;
                    case UserComponents.VKAuth:
                        query = query.Include(_ => _.UserAuthMethods)
                            .ThenInclude(_ => _.VKAuthMethod);
                        break;
                    default:
                        break;
                }
            }

            return query;
        }
    }
    public enum UserComponents
    {
        Inform,
        Details,
        EmailAuth,
        GoogleAuht,
        YandexAuth,
        VKAuth
    }
}
