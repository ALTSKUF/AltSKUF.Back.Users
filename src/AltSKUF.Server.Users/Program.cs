using AltSKUF.Back.Users.Domain;
using AltSKUF.Back.Users.Domain.Interfaces;
using AltSKUF.Back.Users.Domain.Services;
using AltSKUF.Back.Users.Domain.Services.Runtime;
using AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication;
using AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication.Runtime;
using AltSKUF.Back.Users.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMemoryCache();

Configuration.Singleton = builder.Configuration
    .GetSection("DefaultConfiguration")
    .Get<Configuration>() ?? new();

//Configuration.Singleton.DataBaseString = builder.Configuration["ConnectionStrings__userdb"];

builder.Services
    .AddDbContext<GeneralContext>(_ =>
    {
        Console.WriteLine("host is: "+Configuration.Singleton.DataBaseString);
        _.UseNpgsql(Configuration.Singleton.DataBaseString);
    });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IAuthenticationClient, AuthenticationClient>(_ =>
    new(new()
    {
        BaseAddress = new(Configuration.Singleton.AuthenticationServiceAddress)
    }));

builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
