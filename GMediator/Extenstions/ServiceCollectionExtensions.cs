using Microsoft.Extensions.DependencyInjection;
using GMediator.Interfaces;
using System.Reflection;

namespace GMediator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGMediator(this IServiceCollection services)
        {
            services.AddSingleton<IMediator, GMediator.Implementations.Mediator>();

            var handlerInterface = typeof(IRequestHandler<,>);

            // Load entry assembly
            var entryAssembly = Assembly.GetEntryAssembly();

            // Load all referenced assemblies (ONLY your projects)
            var referencedAssemblies = entryAssembly!
                .GetReferencedAssemblies()
                .Select(Assembly.Load)
                .ToList();

            // Also scan the API assembly itself
            referencedAssemblies.Add(entryAssembly);

            // Distinct assemblies
            var assembliesToScan = referencedAssemblies
                .Distinct()
                .ToArray();

            foreach (var asm in assembliesToScan)
            {
                Type[] types;
                try
                {
                    types = asm.GetTypes();
                }
                catch
                {
                    continue;
                }

                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces()
                        .Where(i => i.IsGenericType &&
                                    i.GetGenericTypeDefinition() == handlerInterface);

                    foreach (var handlerType in interfaces)
                    {
                        services.AddTransient(handlerType, type);
                    }
                }
            }

            return services;
        }
    }
}
