using CAD.Core.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CAD.Core.ModelMapping
{
    public static class Extensions
    {
        public static IServiceCollection AddModelMapping(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(item =>
                    item.GetInterfaces().Where(i => i.IsGenericType).Any(
                        i => i.GetGenericTypeDefinition() == typeof(IMapper<,>)
                    )
                    && !item.IsAbstract 
                    && !item.IsInterface
                )
                .ToList()
                .ForEach(assignedType =>
                {
                    //var serviceType = assignedType.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IMapper<,>));
                    services.AddScoped(assignedType);
                });
            return services;
        }
    }
}