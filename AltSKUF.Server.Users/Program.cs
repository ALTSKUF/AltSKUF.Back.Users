using AltSKUF.Back.Users.Domain.Interfaces;
using AltSKUF.Back.Users.Domain.Services;
using AltSKUF.Back.Users.Domain.Services.Runtime;
using AltSKUF.Back.Users.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services
    .AddDbContext<GeneralContext>(_ =>
    {
        _.UseNpgsql("Host=localhost;Port=5432;Database=userdb;Username=postgres;Password=wr3241rt");
    });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

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
