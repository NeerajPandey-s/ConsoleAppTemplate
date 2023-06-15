using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ConsoleApp.Common.ServiceInstallers
{
    public static class MappedTypesFactory
    {
        public static IEnumerable<KeyValuePair<Type, Type>> GetMappedTypesFromAssemblies<TType>(params Assembly[] assemblies)
            where TType : Attribute
        {
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetExportedTypes()
                    .Where(x => x.GetCustomAttribute(typeof(TType)) != null);

                foreach (var type in types)
                {
                    var baseTypes = GetBaseType(type);
                    foreach (var baseType in baseTypes)
                    {
                        yield return new KeyValuePair<Type, Type>(baseType, type);
                    }
                }
            }
        }

        private static List<Type> GetBaseType(Type type)
        {
            var interfaces = type.GetTypeInfo().GetInterfaces();

            if (interfaces.Length == 0)
            {
                return new List<Type> { type };
            }

            return interfaces.ToList();
        }
    }

}