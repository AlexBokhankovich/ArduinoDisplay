namespace ArduinoDisplay.PluginLoader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using ArduinoDisplay.Configuration;
    using ArduinoDisplay.PluginInterface;

    /// <summary>
    ///     The plugin loader.
    /// </summary>
    public static class PluginLoader
    {
        public static ICollection<IArduinoDisplayPlugin> LoadPlugins(string path, Configuration config)
        {
            if (Directory.Exists(path))
            {
                var dllFileNames = Directory.GetFiles(path, "*.dll");

                ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
                foreach (var dllFile in dllFileNames)
                {
                    var an = AssemblyName.GetAssemblyName(dllFile);
                    var assembly = Assembly.Load(an);
                    assemblies.Add(assembly);
                }

                var pluginType = typeof(IArduinoDisplayPlugin);
                ICollection<Type> pluginTypes = new List<Type>();
                foreach (var assembly in assemblies)
                {
                    if (assembly == null)
                    {
                        continue;
                    }

                    var types = assembly.GetTypes();

                    foreach (var type in types)
                    {
                        if (type.IsInterface || type.IsAbstract)
                        {
                        }
                        else
                        {
                            if (type.GetInterface(pluginType.FullName) != null)
                            {
                                pluginTypes.Add(type);
                            }
                        }
                    }
                }

                ICollection<IArduinoDisplayPlugin> plugins = new List<IArduinoDisplayPlugin>(pluginTypes.Count);

                foreach (var pluginCfg in config.Plugins)
                {
                    if (plugins.Any(p => p.Id == pluginCfg.Id))
                    {
                        throw new TypeLoadException($"Couldn't load plugin with the same Id {pluginCfg.Id}");
                    }

                    if (pluginCfg.Id == null)
                    {
                        continue;
                    }

                    var type = pluginTypes.First(t => t.Name == pluginCfg.Name + "Plugin");
                    if (type == null)
                    {
                        continue;
                    }

                    var plugin = (IArduinoDisplayPlugin)Activator.CreateInstance(type);
                    plugin.Id = pluginCfg.Id;
                    plugin.Configure(pluginCfg.Options);
                    plugins.Add(plugin);
                }

                return plugins;
            }

            return null;
        }
    }
}