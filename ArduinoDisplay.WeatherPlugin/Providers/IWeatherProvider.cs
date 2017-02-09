namespace ArduinoDisplay.WeatherPlugin.Providers
{
    using ArduinoDisplay.GeoCommon;

    /// <summary>
    ///     The WeatherProvider interface.
    /// </summary>
    public interface IWeatherProvider
    {
        /// <summary>
        /// Gets the api key.
        /// </summary>
        string ApiKey { get; }

        /// <summary>
        /// Gets or sets the city name.
        /// </summary>
        string CityName { get; set; }

        /// <summary>
        /// Gets or sets the coordinate.
        /// </summary>
        Coordinate Coordinate { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        string CountryCode { get; set; }

        /// <summary>
        ///     Gets the current weather.
        /// </summary>
        string CurrentWeather { get; }
    }
}