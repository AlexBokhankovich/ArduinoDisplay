namespace ArduinoDisplay.WeatherPlugin
{
    using System.Globalization;

    using ArduinoDisplay.PluginInterface;

    /// <summary>
    /// The weather updater.
    /// </summary>
    public class WeatherUpdater : GenericUpdater<WeatherUpdateEventArgs, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherUpdater"/> class.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="updateFrequency">
        /// The update frequency.
        /// </param>
        public WeatherUpdater(IDataProvider<string> provider, int updateFrequency)
            : base(provider, updateFrequency)
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
            var forecastStr = this.Provider.Value;
            var forecast = new ForecastParser(forecastStr).ParseForecast();
            var args = new WeatherUpdateEventArgs(forecast.TemperatureC.ToString(CultureInfo.InvariantCulture));
            this.InvokeDataReadyEvent(args);
        }
    }
}