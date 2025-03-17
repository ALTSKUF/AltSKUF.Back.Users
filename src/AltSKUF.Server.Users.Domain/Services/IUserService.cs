using AltSKUF.Back.Users.Domain.Entity;
using AltSKUF.Back.Users.Persistance.Entity;
using AltSKUF.Back.Users.Persistance.Extensions;

namespace AltSKUF.Back.Users.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(Guid userId, List<UserComponents> userComponents);
        Task<User> GetUser(string email, List<UserComponents> userComponents);
        Task<User> CreateUser(CreateFromEmailUserModel options);
    }
}
