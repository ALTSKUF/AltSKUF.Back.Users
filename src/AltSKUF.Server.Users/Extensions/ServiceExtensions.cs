using AltSKUF.Back.Users.Domain;
using AltSKUF.Back.Users.Domain.Interfaces;
using AltSKUF.Back.Users.Domain.Services.Runtime;
using AltSKUF.Back.Users.Domain.Services;
using AltSKUF.Back.Users.Persistance;
using Microsoft.EntityFrameworkCore;
using AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication.Runtime;
using AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AltSKUF.Back.Users.Extensions
{
    public static class ServiceExtensions
    {
        public static void UseServiceExtensions(this WebApplicationBuilder builder)
        {
            builder.ReadConfiguration();
            builder.AddDatabase();
            builder.AddHttpClient();
            builder.AddServices();
        }

        private static void ReadConfiguration(this WebApplicationBuilder builder)
        {
            Configuration.Singleton = builder.Configuration
                .GetSection("DefaultConfiguration")
                .Get<Configuration>() ?? new();


            Console.WriteLine(Configuration.Singleton.DataBaseString);
        }

        private static void AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddDbContext<GeneralContext>(_ =>
                {
                    _.UseNpgsql(Configuration.Singleton.DataBaseString);
                });
        }

        private static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IVerifyService, VerifyService>();
        }

        private static void AddHttpClient(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthenticationClient, AuthenticationClient>(_ =>
                new(new()
                {
                    BaseAddress = new(Configuration.Singleton.AuthenticationServiceAddress)
                }));
        }

        //private static void AddAuth(this WebApplicationBuilder builder)
        //{
        //    builder.Services.AddAuthentication()
        //        .AddJwtBearer("Services", _ =>
        //        {
        //            _.Audience = "AltSkuf";
        //            _.TokenValidationParameters = new()
        //            {
        //                ValidateIssuer = true,
        //                ValidIssuer = "AltSKUF.Back",
        //                ValidateAudience = true,
        //                ValidAudience = "AltSKUF.Back",
        //                ValidateLifetime = true,
        //                IssuerSigningKey = new SymmetricSecurityKey(
        //                    Encoding.UTF8.GetBytes(Configuration.Singleton.ServiceTokenOptions.Secret)),
        //                ValidateIssuerSigningKey = true,
        //            };
        //        })
        //        .AddJwtBearer("Refresh", _ =>
        //        {
        //            _.Audience = "AltSkuf";
        //            _.TokenValidationParameters = new()
        //            {
        //                ValidateIssuer = true,
        //                ValidIssuer = "AltSKUF.Back",
        //                ValidateAudience = true,
        //                ValidAudience = "AltSKUF.Front",
        //                ValidateLifetime = true,
        //                IssuerSigningKeyResolver =
        //                    (token, secutiryToken, kid, validationParameters) =>
        //                        [TokensSingleton.Singleton.RefreshTokenSecret, TokensSingleton.Singleton.PreviousRefreshTokenSecret],
        //                ValidateIssuerSigningKey = true,
        //            };
        //        });

        //    builder.Services.AddAuthorizationBuilder()
        //        .AddPolicy("Services", policy =>
        //        {
        //            policy.AddAuthenticationSchemes("Services");
        //            policy.RequireAuthenticatedUser();
        //        })
        //        .AddPolicy("Refresh", policy =>
        //        {
        //            policy.AddAuthenticationSchemes("Refresh");
        //            policy.RequireAuthenticatedUser();
        //        });
        //}

        private static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Add JWT authorization support
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // Must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {securityScheme, new string[] { }}
                    });
            });
        }
    }
}
