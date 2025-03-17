using System.ComponentModel.DataAnnotations.Schema;

namespace AltSKUF.Back.Users.Persistance.Entity.AuthMethods
{
    [Table("EmailAuthMethods")]
    public class EmailAuthMethod : AuthMethod
    {
        [Column("password")]
        public string Password { get; set; } = string.Empty;
    }
}
