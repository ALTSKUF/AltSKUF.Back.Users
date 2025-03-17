using AltSKUF.Back.Users.Persistance.Entity;
using AltSKUF.Back.Users.Persistance.Entity.AuthMethods;
using Microsoft.EntityFrameworkCore;

namespace AltSKUF.Back.Users.Persistance
{
    public class GeneralContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserInform> UserInforms { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

        public DbSet<UserAuthMethods> AuthMethods { get; set; }
        public DbSet<EmailAuthMethod> EmailAuthMethods { get; set; }
        public DbSet<GoogleAuthMethod> GoogleAuthMethods { get; set; }
        public DbSet<YandexAuthMethod> YandexAuthMethods { get; set; }
        public DbSet<VKAuthMethod> VKAuthMethods { get; set; }


        public GeneralContext(DbContextOptions<GeneralContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
