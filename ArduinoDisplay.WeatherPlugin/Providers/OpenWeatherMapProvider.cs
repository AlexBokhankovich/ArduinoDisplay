namespace ArduinoDisplay.WeatherPlugin.Providers
{
    using System;
    using System.Net.Http;

    using ArduinoDisplay.GeoCommon;

    /// <summary>
    ///     The yandex weather provider.
    /// </summary>
    public class OpenWeatherMapProvider : IWeatherProvider
    {
        /// <summary>
        /// The api base url.
        /// </summary>
        private readonly string apiBaseUrl = $"http://api.openweathermap.org/data/2.5/";

        /// <summary>
        /// The client.
        /// </summary>
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenWeatherMapProvider"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The api key.
        /// </param>
        public OpenWeatherMapProvider(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// Gets the api key.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Gets or sets the city name.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets the coordinate.
        /// </summary>
        public Coordinate Coordinate { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// The value.
        /// </summary>
        public string CurrentWeather => string.IsNullOrEmpty(this.CityName)
                    ? this.GetCurrentWeather(this.Coordinate)
                    : this.GetCurrentWeather(this.CityName);

        /// <summary>
        /// The request.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string Request(string url, HttpMethod method = null)
        {
            method = method == null ? HttpMethod.Get : method;

            var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = method };

            var response = this.client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;

            return response;
        }

        /// <summary>
        /// The get current weather.
        /// </summary>
        /// <param name="coordinate">
        /// The coordinate.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetCurrentWeather(Coordinate coordinate)
        {
            return
                this.Request(
                    this.apiBaseUrl + $"weather?lat={coordinate.Latitude}&long={coordinate.Longitude}"
                    + $"&APPID={this.ApiKey}");
        }

        /// <summary>
        /// The get current weather.
        /// </summary>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <param name="country">
        /// The country.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetCurrentWeather(string city, string country = null)
        {
            return
                this.Request(
                    this.apiBaseUrl + $"weather?q={city}"
                    + (string.IsNullOrEmpty(country) ? string.Empty : $",{country}") + $"&APPID={this.ApiKey}");
        }
    }
}