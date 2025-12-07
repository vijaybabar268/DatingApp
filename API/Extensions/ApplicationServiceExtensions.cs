using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationSevices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options => // Register database as service
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnectionString"));
            });
            services.AddCors(); // Register CORS
            services.AddScoped<ITokenService, TokenService>(); // Custom service            

            return services;
        }
    }
}
