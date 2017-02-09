namespace ArduinoDisplay.SystemInfoPlugin
{
    /// <summary>
    /// The system info config.
    /// </summary>
    public class SystemInfoConfig
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the update interval.
        /// </summary>
        public int UpdateInterval { get; set; }
    }
}