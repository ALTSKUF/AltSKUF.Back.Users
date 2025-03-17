using AltSKUF.Back.Users.Domain.Entity;
using AltSKUF.Back.Users.Domain.Entity.AddMethods;
using AltSKUF.Back.Users.Persistance.Entity;

namespace AltSKUF.Back.Users.Domain.Services
{
    public interface IAuthService
    {
        Task<Guid> AuthFromEmail(AuthFromEmailUserModel options);

        Task<User> AddMethod(AddEmailMethodModel options);
        Task<User> AddMethod(AddGoogleMethodModel options);
        Task<User> AddMethod(AddYandexMethodModel options);
        Task<User> AddMethod(AddVKMethodModel options);
    }
}
