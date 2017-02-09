namespace ArduinoDisplay.WeatherPlugin
{
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// The weather config.
    /// </summary>
    public class WeatherConfig
    {
        /// <summary>
        /// Gets or sets the api key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the update interval.
        /// </summary>
        public int UpdateInterval { get; set; }
    }
}