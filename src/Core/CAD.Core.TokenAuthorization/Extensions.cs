using Microsoft.Extensions.DependencyInjection;
using CAD.Core.Shared.Interfaces;

namespace CAD.Core.TokenAuthorization
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
