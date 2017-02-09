namespace ArduinoDisplay.SystemInfoPlugin
{
    using System;

    using ArduinoDisplay.PluginInterface;
    using ArduinoDisplay.SystemInfoPlugin.OhwMonitor;

    using OpenHardwareMonitor.Hardware;

    /// <summary>
    /// The system info data provider.
    /// </summary>
    public class SystemInfoDataProvider : IDataProvider<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemInfoDataProvider"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        public SystemInfoDataProvider(HardwareType hwType, SensorType sensorType, string name, string format = null)
        {
            this.SensorType = sensorType;
            this.HardwareType = hwType;
            this.OpenHwMon = new OpenHardwareMonitorWrapper(hwType, sensorType, name);
            format = format ?? "{0}";
            this.Format = format;
        }

        /// <summary>
        /// Gets or sets the open hw mon.
        /// </summary>
        public OpenHardwareMonitorWrapper OpenHwMon { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public SensorType SensorType { get; }

        /// <summary>
        /// Gets or sets the hardware type.
        /// </summary>
        public HardwareType HardwareType { get; }

        /// <summary>
        /// The value.
        /// </summary>
        public string Value => this.GetValue();

        /// <summary>
        /// Gets the format.
        /// </summary>
        private string Format { get; }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetValue()
        {
            return string.Format(this.Format,Convert.ToInt32(this.OpenHwMon.Value));
        }
    }
}