using AltSKUF.Back.Users.Persistance.Entity;

namespace AltSKUF.Back.Users.Domain.Entity.AddMethods
{
    public abstract class AddAuthMethodModel
    {
        public User User { get; set; } = new();

        public string Email { get; set; } = string.Empty;
    }
}
