namespace ArduinoDisplay.WeatherPlugin
{
    using System;

    using ArduinoDisplay.GeoCommon;
    using ArduinoDisplay.GeoLocation;
    using ArduinoDisplay.PluginInterface;
    using ArduinoDisplay.WeatherPlugin.Providers;

    /// <summary>
    ///     The forecaster.
    /// </summary>
    public class ForecastProvider : IDataProvider<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForecastProvider"/> class.
        /// </summary>
        /// <param name="weatherProvider">
        /// The weather provider.
        /// </param>
        /// <param name="weatherProviderapiKey">
        /// The weather providerapi key.
        /// </param>
        /// <param name="coord">
        /// The coord.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public ForecastProvider(
            IWeatherProvider weatherProvider,
            Coordinate coord = null,
            string cityName = null,
            string countryCode = null)
        {
            var geoProv = new GeoLocationProvider();
            coord = coord ?? new GeoLocationProvider().Coordinate;

            cityName = cityName ?? geoProv.City;
            countryCode = geoProv.CountryCode;
            weatherProvider.Coordinate = coord;
            weatherProvider.CityName = cityName;
            weatherProvider.CountryCode = countryCode;

            this.WeatherProvider = weatherProvider;
            this.Coordinate = coord;
        }

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        public Coordinate Coordinate { get; }

        /// <summary>
        ///     Gets or sets the forecast.
        /// </summary>
        public string Value => this.GetForecast();

        /// <summary>
        ///     Gets the weather provider.
        /// </summary>
        private IWeatherProvider WeatherProvider { get; }

        /// <summary>
        ///     The get forecast.
        /// </summary>
        /// <returns>
        ///     The <see cref="Forecast" />.
        /// </returns>
        private string GetForecast()
        {
            return this.WeatherProvider.CurrentWeather;
        }
    }
}