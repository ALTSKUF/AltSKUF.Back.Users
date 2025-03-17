using System.ComponentModel.DataAnnotations.Schema;
using AltSKUF.Back.Users.Persistance.Entity.AuthMethods;

namespace AltSKUF.Back.Users.Persistance.Entity
{
    [Table("UserAuthMethods")]
    public class UserAuthMethods
    {
        public Guid Id { get; set; }
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("email_auth")]
        public EmailAuthMethod? EmailAuthMethod { get; set; } = default!;
        [Column("google_auth")]
        public GoogleAuthMethod? GoogleAuthMethod { get; set; } = default!;
        [Column("yandex_auth")]
        public YandexAuthMethod? YandexAuthMethod { get; set; } = default!;
        [Column("vk_auth")]
        public VKAuthMethod? VKAuthMethod { get; set; } = default!;

        [Column("user")]
        public User User { get; set; } = default!;
    }
}
