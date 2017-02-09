namespace ArduinoDisplay.SystemInfoPlugin
{
    using System;

    using ArduinoDisplay.PluginInterface;

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
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public SystemInfoDataProvider(SysInfoType type, string format = null)
        {
            this.Type = type;

            switch (type)
            {
                case SysInfoType.CpuUtilization:
                    this.PrefCounterWrapper = new PerformanceCounterWrapper("Processor", "% Processor Time", "_Total");
                    format = format ?? "CPU: {0}%";
                    break;
                case SysInfoType.RamFree:
                    this.PrefCounterWrapper = new PerformanceCounterWrapper("Memory", "Available MBytes", string.Empty);
                    format = format ?? "RAM FREE: {0}";
                    break;
                case SysInfoType.RamUtilization:
                    // TODO change
                    this.PrefCounterWrapper = new PerformanceCounterWrapper("Memory", "Available MBytes", string.Empty);
                    format = format ?? "RAM Used: {0}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            this.Format = format;
        }

        /// <summary>
        /// Gets or sets the pref counter wrapper.
        /// </summary>
        public PerformanceCounterWrapper PrefCounterWrapper { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public SysInfoType Type { get; set; }

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
            return string.Format(this.Format, this.PrefCounterWrapper.GetCurrentValue());
            //return string.Format(this.Format, MemoryInfo.ShowMemory());
        }
    }
}