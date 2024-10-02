using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.BL.Services;
using WebAPI.DAL;

namespace WebAPI.BL.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceConfig(this IServiceCollection services, ConfigurationManager config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlite(config.GetConnectionString("DefaultConntection"));
            });

            services.AddScoped<ProductService>();
            services.AddScoped<ManufacturerService>();

            return services;
        }
    }
}
