using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AltSKUF.Back.Users.Persistance.Entity
{
    [Table("UserInforms")]
    [Index(nameof(Email), IsUnique = true)]
    public class UserInform
    {
        public Guid Id { get; set; }
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("user_name")]
        public string UserName { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;
        [Column("confirmed_email")]
        public bool Confirmed_email { get; set; } = false;

        [Column("role")]
        public string Role { get; set; } = string.Empty;

        [Column("user")]
        public User User { get; set; } = default!;
    }
}
