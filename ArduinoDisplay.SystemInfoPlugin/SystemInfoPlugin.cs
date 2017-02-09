namespace ArduinoDisplay.SystemInfoPlugin
{
    using System;

    using ArduinoDisplay.PluginInterface;

    using OpenHardwareMonitor.Hardware;

    /// <summary>
    /// The system info.
    /// </summary>
    public class SystemInfoPlugin : IArduinoDisplayPlugin
    {
        /// <summary>
        /// The data ready.
        /// </summary>
        public event EventHandler<DataReadyEventArgs> DataReady;

        /// <summary>
        /// Gets or sets the config.
        /// </summary>
        public SystemInfoConfig Config { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name => "SystemInfo";

        /// <summary>
        /// The type.
        /// </summary>
        public HardwareType HardwareType => (HardwareType)Enum.Parse(typeof(HardwareType), this.Config.HardwareType);

        public SensorType SensorType => (SensorType)Enum.Parse(typeof(SensorType), this.Config.SensorType);

        public string SensorName => this.Config.SensorName;


        /// <summary>
        ///     Gets or sets the datetime provider.
        /// </summary>
        private IDataProvider<string> Provider { get; set; }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public void Configure(dynamic config)
        {
            this.Config = new SystemInfoConfig
                              {
                                  UpdateInterval = config.UpdateInterval ?? 1000,
                                  Format = config.Format,
                                  HardwareType = config.HardwareType,
                                  SensorType = config.SensorType,
                                  SensorName = config.SensorName
            };
        }

        /// <summary>
        /// The init.
        /// </summary>
        public void Init()
        {
            this.Provider = new SystemInfoDataProvider(this.HardwareType, this.SensorType, this.SensorName, this.Config.Format);
        }

        /// <summary>
        /// The start.
        /// </summary>
        public void Start()
        {
            var updater = new SystemInfoDataUpdater(this.Provider, this.Config.UpdateInterval);
            updater.DataReady += this.SysInfoProviderDataReady;
            updater.Start();
        }

        /// <summary>
        ///     The on data ready.
        /// </summary>
        /// <param name="e">
        ///     The e.
        /// </param>
        protected virtual void OnDataReady(DataReadyEventArgs e)
        {
            this.DataReady?.Invoke(this, e);
        }

        /// <summary>
        ///     The datetime provider data ready.
        /// </summary>
        /// <param name="sender">
        ///     The sender.
        /// </param>
        /// <param name="e">
        ///     The e.
        /// </param>
        private void SysInfoProviderDataReady(object sender, DataReadyEventArgs e)
        {
            var datareadyEventArgs = new DataReadyEventArgs(e.NewData);
            this.OnDataReady(datareadyEventArgs);
        }
    }
}