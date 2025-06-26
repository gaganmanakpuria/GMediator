using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using GMediator.Interfaces;

namespace GMediator.Extensions
{
    public static class ServiceCollectionExtensions
    {
       public static IServiceCollection AddGMediator(this IServiceCollection services)
        {
            services.AddSingleton<IMediator>(sp => new GMediator.Implementations.Mediator(sp));

            var handlerInterfaceType = typeof(IRequestHandler<,>);
            var assemblies = new[] {  Assembly.GetCallingAssembly() };

            foreach (var asm in assemblies)
            {
                var types = asm.GetTypes();

                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType);

                    foreach (var @interface in interfaces)
                    {
                        services.AddTransient(@interface, type);
                    }
                }
            }

            return services;
        }

    }
}
