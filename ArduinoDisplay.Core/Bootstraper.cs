namespace ArduinoDisplay.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using ArduinoDisplay.PluginInterface;


    /// <summary>
    ///     The bootstraper.
    /// </summary>
    public class Bootstraper
    {
        /// <summary>
        ///     Gets or sets the plugins.
        /// </summary>
        public List<IArduinoDisplayPlugin> Plugins { get; set; }

        /// <summary>
        ///     The start.
        /// </summary>
        public void Start()
        {
            this.Plugins = new List<IArduinoDisplayPlugin>();
            var cfgMan = new ConfigManager();
            cfgMan.Load();

            var config = cfgMan.Config;

            var plugins = PluginLoader.PluginLoader.LoadPlugins("Plugins", config);

            foreach (var item in plugins)
            {
                this.Plugins.Add(item);
            }
        }
    }
}