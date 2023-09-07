using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CAD.Core.Shared.Interfaces;
using CAD.Infrastructure.Data.Repositories;

namespace CAD.Infrastructure.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddPersistentStorage(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<CompanyDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            return services;
        }

        public static void InitializeDatabase(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                CompanyDbContext dbContext = scope.ServiceProvider.GetService<CompanyDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
