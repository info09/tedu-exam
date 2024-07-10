using Identity.API.Database;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
