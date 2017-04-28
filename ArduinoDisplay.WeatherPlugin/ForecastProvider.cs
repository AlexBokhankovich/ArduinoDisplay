namespace ArduinoDisplay.WeatherPlugin
{
    using System;
    using System.Net;

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
        /// The format.
        /// </summary>
        private readonly string format;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForecastProvider"/> class.
        /// </summary>
        /// <param name="weatherProvider">
        /// The weather provider.
        /// </param>
        /// <param name="coord">
        /// Coordinates of the city to get weather for
        /// </param>
        /// <param name="cityName">
        /// City name
        /// </param>
        /// <param name="countryCode">
        /// Country code
        /// </param>
        /// <param name="format">
        /// Weather output format
        /// </param>
        public ForecastProvider(
            IWeatherProvider weatherProvider,
            Coordinate coord = null,
            string cityName = null,
            string countryCode = null,
            string format = null)
        {
            this.format = format ?? "{0}";
            var geoProv = new GeoLocationProvider();
            coord = coord ?? new GeoLocationProvider().Coordinate;

            cityName = cityName ?? geoProv.City;
            countryCode = countryCode ?? geoProv.CountryCode;
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
            try
            {
                var forecast =
                    new ForecastParser(this.WeatherProvider.CurrentWeather).ParseForecast(
                        this.WeatherProvider.WeatherDataFormat);
                return string.Format(this.format, forecast.TemperatureC.ToString("0.00"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}