using CAD.Core.ModelMapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CAD.Core.UseCases
{
    public static class Extensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddMediatR( x =>
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );
            services.AddModelMapping();
            return services;
        }
    }
}
