using AltSKUF.Back.Users.Domain.Entity;
using AltSKUF.Back.Users.Domain.Entity.AddMethods;
using AltSKUF.Back.Users.Infrastructure.Entity.Requests;
using AltSKUF.Back.Users.Infrastructure.Entity.Responce;
using AltSKUF.Back.Users.Persistance.Entity;

namespace AltSKUF.Back.Users.Extensions
{
    public static class ModelExtensions
    {
        public static AuthFromEmailUserModel ToAuthModel(this UserEmailAuthRequest request)
        {
            return new()
            {
                Email = request.Email,
                Password = request.Password,
            };
        }

        public static CreateFromEmailUserModel ToCreateModel(this UserEmailRegistrationRequest request)
        {
            return new()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = request.Role,
                UserName = request.UserName
            };
        }

        public static AddEmailMethodModel ToAddEmailMethodModel(this UserEmailRegistrationRequest request,
            User user)
        {
            return new()
            {
                Email = request.Email,
                Password = request.Password,
                User = user
            };
        }

        public static UserResponce ToResponce(this User user)
        {
            return new()
            {
                UserId = user.Id,
                Email = user.UserInform.Email,
                UserName = user.UserInform.UserName,
                FirstName = user.UserDetails.FirstName,
                LastName = user.UserDetails.LastName,
                Role = user.UserInform.Role
            };
        }
    }
}
