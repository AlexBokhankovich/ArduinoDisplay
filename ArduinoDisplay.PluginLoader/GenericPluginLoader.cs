//namespace SimplePlugin
//{
//    using System;
//    using System.Collections.Generic;
//    using System.IO;
//    using System.Linq;
//    using System.Reflection;

//    using ArduinoDisplay.Configuration;

//    /// <summary>
//    ///     The generic plugin loader.
//    /// </summary>
//    /// <typeparam name="T">
//    /// </typeparam>
//    public static class GenericPluginLoader<T>
//    {
//        /// <summary>
//        /// The load plugins.
//        /// </summary>
//        /// <param name="path">
//        ///     The path.
//        /// </param>
//        /// <param name="config"></param>
//        /// <returns>
//        /// The <see cref="ICollection"/>.
//        /// </returns>
//        public static ICollection<T> LoadPlugins(string path, Configuration config)
//        {
//            if (Directory.Exists(path))
//            {
//                var dllFileNames = Directory.GetFiles(path, "*.dll");

//                ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
//                foreach (var dllFile in dllFileNames)
//                {
//                    var an = AssemblyName.GetAssemblyName(dllFile);
//                    var assembly = Assembly.Load(an);
//                    assemblies.Add(assembly);
//                }

//                var pluginType = typeof(T);
//                ICollection<Type> pluginTypes = new List<Type>();
//                foreach (var assembly in assemblies)
//                {
//                    if (assembly == null)
//                    {
//                        continue;
//                    }

//                    var types = assembly.GetTypes();

//                    foreach (var type in types)
//                    {
//                        if (type.IsInterface || type.IsAbstract)
//                        {
//                        }
//                        else
//                        {
//                            if (type.GetInterface(pluginType.FullName) != null)
//                            {
//                                pluginTypes.Add(type);
//                            }
//                        }
//                    }
//                }

//                ICollection<T> plugins = new List<T>(pluginTypes.Count);


//                foreach (var pluginCfg in config.Plugins)
//                {
//                    var type = pluginTypes.First(t => t.Name == pluginCfg.Name + "Plugin");
//                    if (type != null)
//                    {
//                        var plugin = (T)Activator.CreateInstance(type);
//                        plugin.Configure(pluginCfg.Options);
//                        plugins.Add(plugin);
//                    }
//                }

//                return plugins;
//            }

//            return null;
//        }
//    }
//}