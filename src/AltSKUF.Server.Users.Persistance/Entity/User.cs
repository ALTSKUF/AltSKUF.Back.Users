using System.ComponentModel.DataAnnotations.Schema;

namespace AltSKUF.Back.Users.Persistance.Entity
{
    [Table("Users")]
    public class User
    {
        public Guid Id { get; set; }

        [Column("user_inform")]
        public UserInformation UserInform { get; set; } = default!;
        [Column("user_details")]
        public UserDetails UserDetails { get; set; } = default!;

        [Column("auth_methods")]
        public UserAuthMethods UserAuthMethods { get; set; } = default!;
    }
}
