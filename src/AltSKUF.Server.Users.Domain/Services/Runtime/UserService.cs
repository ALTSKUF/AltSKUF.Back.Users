using AltSKUF.Back.Users.Domain.Entity;
using AltSKUF.Back.Users.Domain.Extensions;
using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions;
using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.NotFoundExceptions;
using AltSKUF.Back.Users.Domain.Interfaces;
using AltSKUF.Back.Users.Persistance;
using AltSKUF.Back.Users.Persistance.Entity;
using AltSKUF.Back.Users.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AltSKUF.Back.Users.Domain.Services.Runtime
{
    public class UserService(GeneralContext db) : IUserService
    {
        public async Task<User> CreateUser(CreateFromEmailUserModel options)
        {
            if (await CheckExtensions.CheckEmail(db, options.Email))
                throw new IsAvalaibleExcepion("user");

            User user = new()
            {
                UserInform = new()
                {
                    Email = options.Email,
                    UserName = options.UserName,
                    Role = options.Role ?? "none"
                },
                UserDetails = new()
                {
                    FirstName = options.FirstName ?? string.Empty,
                    LastName = options.LastName ?? string.Empty,
                },
                UserAuthMethods = new()
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            return user;
        }

        public async Task<User> EditUser(User user, EditUserOptions options)
        {
            if (options.UserName != null) user.UserInform.UserName = options.UserName;
            if (options.Email != null) user.UserInform.Email = options.Email;
            if (options.ConfirmedEmail) user.UserInform.ConfirmedEmail = options.ConfirmedEmail;
            if (options.Role != null) user.UserInform.Role = options.Role;

            if (options.FirstName != null) user.UserDetails.FirstName = options.FirstName;
            if (options.LastName != null) user.UserDetails.LastName = options.LastName ;

            db.Users.Update(user);
            await db.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUser(Guid userId,
            List<UserComponents> userComponents)
        {
            var user = await db.Users
                .IncludingUserQuery(userComponents)
                .FirstOrDefaultAsync(_ => _.Id == userId);

            if (user != null) return user;
            throw new NotFoundException("user");
        }

        public async Task<User> GetUser(string email,
            List<UserComponents> userComponents)
        {
            userComponents.Add(UserComponents.Inform);
            var user = await db.Users
                .IncludingUserQuery(userComponents)
                .FirstOrDefaultAsync(_ => _.UserInform.Email == email);

            if (user != null) return user;
            throw new NotFoundException("user");
        }
    }
}
