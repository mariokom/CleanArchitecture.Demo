using Microsoft.Extensions.DependencyInjection;
using CAD.Core.Shared.Interfaces;

namespace CAD.Core.Cryptography
{
    public static class Extensions
    {
        public static IServiceCollection AddHashing(this IServiceCollection services)
        {
            services.AddScoped<IHashManager, HashManager>();
            return services;
        }

    }
}
