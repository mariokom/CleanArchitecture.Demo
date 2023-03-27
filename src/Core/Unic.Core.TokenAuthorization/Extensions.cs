using Microsoft.Extensions.DependencyInjection;
using Unic.Core.Shared.Interfaces;

namespace Unic.Core.TokenAuthorization
{
    public static class Extensions
    {
        public static IServiceCollection AddTokenAuthorization(this IServiceCollection services)
        {
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<AuthorizationContext>();
            return services;
        }
    }
}
