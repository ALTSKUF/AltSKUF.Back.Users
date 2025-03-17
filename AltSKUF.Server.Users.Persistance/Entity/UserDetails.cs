using System.ComponentModel.DataAnnotations.Schema;

namespace AltSKUF.Back.Users.Persistance.Entity
{
    [Table("UserDetails")]
    public class UserDetails
    {
        public Guid Id { get; set; }
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;
        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        [Column("user")]
        public User User { get; set; } = default!;
    }
}
