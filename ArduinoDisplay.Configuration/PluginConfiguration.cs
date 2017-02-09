namespace ArduinoDisplay.Configuration
{
    /// <summary>
    /// The plugin configuration.
    /// </summary>
    public class PluginConfiguration
    {
        /// <summary>
        /// Gets or sets the plugin unique Id
        /// It is required to have unique Id for plugin to work correctly
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the plugin name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the plugin options.
        /// </summary>
        public dynamic Options { get; set; }
    }
}