// Add services to the container.
using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => // Register database as service
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
builder.Services.AddCors(); // Register CORS


// Configure the HTTP request pipeline.
var app = builder.Build();

app.UseCors(x =>
{
    x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","https://localhost:4200");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
