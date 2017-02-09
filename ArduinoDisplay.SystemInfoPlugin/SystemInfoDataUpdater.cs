namespace ArduinoDisplay.SystemInfoPlugin
{
    using ArduinoDisplay.PluginInterface;

    /// <summary>
    /// The system info data updater.
    /// </summary>
    public class SystemInfoDataUpdater : GenericUpdater<SysInfoReadyArgs, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemInfoDataUpdater"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        public SystemInfoDataUpdater(IDataProvider<string> provider, int updateFreq)
            : base(provider, updateFreq)
        {
        }

        /// <summary>
        /// The on timer elapsed.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        protected override void OnTimerElapsed(object state)
        {
            this.InvokeDataReadyEvent(new SysInfoReadyArgs(this.Provider.Value));
        }
    }
}