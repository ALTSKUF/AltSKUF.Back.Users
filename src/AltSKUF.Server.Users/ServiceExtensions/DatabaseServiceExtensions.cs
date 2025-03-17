using AltSKUF.Back.Users.Persistance;
using Microsoft.EntityFrameworkCore;

namespace AltSKUF.Back.Users.ServiceExtensions
{
    public static class DatabaseServiceExtensions
    {
        public static void Database(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddDbContext<GeneralContext>(_ =>
                {
                    _.UseNpgsql("Host=localhost;Port=5433;Database=userdb;Username=postgres;Password=wr3241rt");
                });
        }
    }
}
