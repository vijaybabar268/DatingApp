using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => // Register database as service
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
builder.Services.AddCors(); // Register CORS
builder.Services.AddScoped<ITokenService, TokenService>(); // Custom service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // Added Authentication
        .AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });



// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseCors(x =>
{
    x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200", "https://localhost:4200");
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
