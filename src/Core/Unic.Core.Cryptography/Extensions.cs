using Microsoft.Extensions.DependencyInjection;
using Unic.Core.Shared.Interfaces;

namespace Unic.Core.Cryptography
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
