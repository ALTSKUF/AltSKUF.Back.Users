using AltSKUF.Back.Users.Domain.Entity;
using AltSKUF.Back.Users.Domain.Entity.AddMethods;
using AltSKUF.Back.Users.Domain.Extensions;
using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions;
using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.NotFoundExceptions;
using AltSKUF.Back.Users.Persistance;
using AltSKUF.Back.Users.Persistance.Entity;
using AltSKUF.Back.Users.Persistance.Entity.AuthMethods;
using Microsoft.EntityFrameworkCore;

namespace AltSKUF.Back.Users.Domain.Services.Runtime
{
    public class AuthService(GeneralContext db) : IAuthService
    {
        public async Task<User> AddMethod(AddEmailMethodModel options)
        {
            if (await CheckExtensions.CheckEmail(
                db, options.Email)) throw new NotFoundException("email");

            EmailAuthMethod authModel = new()
            {
                Email = options.Email,
                Password = options.Password.HashedPassword(),
            };

            options.User.UserAuthMethods.EmailAuthMethod = authModel;
            db.Users.Update(options.User);
            await db.SaveChangesAsync();

            return options.User;
        }

        public Task<User> AddMethod(AddGoogleMethodModel options)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddMethod(AddYandexMethodModel options)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddMethod(AddVKMethodModel options)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> AuthFromEmail(AuthFromEmailUserModel options)
        {
            var authModel = await db
                .EmailAuthMethods
                .Include(_ => _.UserAuthMethods)
                .FirstOrDefaultAsync(_ => _.Email == options.Email) ?? throw new NotFoundException("auth_method");

            if (HashedExtensions.VerifyPassword(options.Password, authModel.Password))
                return authModel.UserAuthMethods.UserId;

            throw new AuthorizationException("user");
        }
    }
}
