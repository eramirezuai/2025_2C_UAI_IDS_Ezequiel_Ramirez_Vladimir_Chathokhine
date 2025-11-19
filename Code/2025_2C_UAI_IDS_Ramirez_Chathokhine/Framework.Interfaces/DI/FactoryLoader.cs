using System;
using System.Linq;

namespace Framework.DI
{
    public static class FactoryLoader
    {
        public static void LoadAll()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var loaderTypes = assembly.GetTypes()
                    .Where(t => typeof(IFactoryLoader).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                foreach (var type in loaderTypes)
                {
                    try
                    {
                        var instance = Activator.CreateInstance(type) as IFactoryLoader;
                        instance?.LoadClasses();
                    }
                    catch (Exception ex)
                    {
                        throw new FactoryLoadException(type, ex);
                    }
                }
            }
        }
    }
}
