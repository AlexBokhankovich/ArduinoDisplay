namespace ArduinoDisplay.SystemInfoPlugin
{
    /// <summary>
    /// The system info config.
    /// </summary>
    public class SystemInfoConfig
    {
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the hardware type.
        /// </summary>
        public string HardwareType { get; set; }

        /// <summary>
        /// Gets or sets the sensor name.
        /// </summary>
        public string SensorName { get; set; }

        /// <summary>
        /// Gets or sets the sensor type.
        /// </summary>
        public string SensorType { get; set; }

        /// <summary>
        /// Gets or sets the update interval.
        /// </summary>
        public int UpdateInterval { get; set; }
    }
}