using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AltSKUF.Back.Users.Persistance.Entity.AuthMethods
{
    [Index(nameof(Email), IsUnique = true)]
    public abstract class AuthMethod
    {
        public Guid Id { get; set; }
        [Column("user_auth_methods_id")]
        public Guid UserAuthMethodsId { get; set; }

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        public UserAuthMethods UserAuthMethods { get; set; } = default!;
    }
}