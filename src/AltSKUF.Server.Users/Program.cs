using AltSKUF.Back.RestClient.Authentication;
using AltSKUF.Back.RestClient.Authentication.Runtime;
using AltSKUF.Back.Users.Domain;
using AltSKUF.Back.Users.Domain.Interfaces;
using AltSKUF.Back.Users.Domain.Services;
using AltSKUF.Back.Users.Domain.Services.Runtime;
using AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication.Runtime;
using AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication;
using AltSKUF.Back.Users.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Configuration.AddEnvironmentVariables();


Configuration.Singleton.DataBaseString = builder.Configuration["ConnectionStrings:userdb"];

Configuration.Singleton.AuthenticationServiceAddress = builder.Configuration["AuthenticationServiceAddress"];

Console.WriteLine("Here" + Configuration.Singleton.DataBaseString);


builder.Services
    .AddDbContext<GeneralContext>(_ =>
    {
        _.UseNpgsql(Configuration.Singleton.DataBaseString);
    });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IAuthenticationClient, AuthenticationClient>(_ =>
    new(GlobalSingletons.Singletons.AuthenricationClient));

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
