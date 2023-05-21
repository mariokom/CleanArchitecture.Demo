using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CAD.Core.Shared.Interfaces;
using CAD.Infrastructure.Data.Repositories;

namespace CAD.Infrastructure.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            return services;
        }

        public static void InitializeDatabase(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                AppDbContext dbContext = scope.ServiceProvider.GetService<AppDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
