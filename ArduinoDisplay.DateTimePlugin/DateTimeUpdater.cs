namespace ArduinoDisplay.DateTimePlugin
{
    using System;

    using ArduinoDisplay.PluginInterface;

    /// <summary>
    /// The date time updater.
    /// </summary>
    public class DateTimeUpdater : GenericUpdater<DataReadyEventArgs, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeUpdater"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="updateFrequency">
        /// The update frequency.
        /// </param>
        public DateTimeUpdater(IDataProvider<string> provider, int updateFrequency)
            : base(provider, updateFrequency)
        {
        }

        /// <summary>
        /// The on timer elapsed.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        protected override void OnTimerElapsed(object state)
        {
            this.InvokeDataReadyEvent(new DataReadyEventArgs(this.Provider.Value));
        }
    }
}