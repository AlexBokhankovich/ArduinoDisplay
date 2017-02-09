namespace ArduinoDisplay.DateTimePlugin
{
    using System;

    using ArduinoDisplay.PluginInterface;

    /// <summary>
    ///     The class 1.
    /// </summary>
    public class DateTimePlugin : IArduinoDisplayPlugin
    {
        /// <summary>
        ///     The data ready.
        /// </summary>
        public event EventHandler<DataReadyEventArgs> DataReady;

        /// <summary>
        /// Gets or sets the config.
        /// </summary>
        public DateTimeConfig Config { get; set; }

        /// <summary>
        ///     The name.
        /// </summary>
        public string Name => "DateTime";

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
            this.Config = new DateTimeConfig
                              {
                                  UpdateInterval = config.UpdateInterval ?? 1000,
                                  Format = config.Format ?? null
                              };
        }

        /// <summary>
        ///     The init.
        /// </summary>
        public void Init()
        {
            this.Provider = new DateTimeProvider(this.Config.Format);
        }

        /// <summary>
        ///     The start.
        /// </summary>
        public void Start()
        {
            var updater = new DateTimeUpdater(this.Provider, this.Config.UpdateInterval);
            updater.DataReady += this.DatetimeProviderDataReady;
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
        private void DatetimeProviderDataReady(object sender, DateTimeEventArgs e)
        {
            var datareadyEventArgs = new DataReadyEventArgs(e.DateTime);
            this.OnDataReady(datareadyEventArgs);
        }
    }
}