﻿using Microsoft.Extensions.DependencyInjection;
using ConsoleApp.Common.ServiceInstallers.Attributes;
using System.Reflection;

namespace ConsoleApp.Common.ServiceInstallers.Extentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.RegisterTransientServices(assemblies);
            services.RegisterScopedServices(assemblies);
            services.RegisterSingletonServices(assemblies);

            return services;
        }

        private static IServiceCollection RegisterTransientServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            var mappedTypes = MappedTypesFactory.GetMappedTypesFromAssemblies<TransientServiceAttribute>(assemblies);

            foreach (var mappedType in mappedTypes)
                services.AddTransient(mappedType.Key, mappedType.Value);

            return services;
        }

        private static IServiceCollection RegisterScopedServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            var mappedTypes = MappedTypesFactory.GetMappedTypesFromAssemblies<ScopedServiceAttribute>(assemblies);

            foreach (var mappedType in mappedTypes)
                services.AddScoped(mappedType.Key, mappedType.Value);

            return services;
        }

        private static IServiceCollection RegisterSingletonServices(this IServiceCollection services, params Assembly[] assemblies)
        {
            var mappedTypes = MappedTypesFactory.GetMappedTypesFromAssemblies<SingletonServiceAttribute>(assemblies);

            foreach (var mappedType in mappedTypes)
                services.AddSingleton(mappedType.Key, mappedType.Value);

            return services;
        }
    }

}

