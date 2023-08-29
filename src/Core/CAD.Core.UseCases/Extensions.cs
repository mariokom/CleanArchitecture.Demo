using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CAD.Core.UseCases
{
    public static class Extensions
    {
        // string enhancement1

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddMediatR( x =>
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );
            return services;
        }
    }
}
