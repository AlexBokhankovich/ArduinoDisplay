namespace ArduinoDisplay.WeatherPlugin
{
    using System;

    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     The forecast parser.
    /// </summary>
    public class ForecastParser
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ForecastParser" /> class.
        /// </summary>
        /// <param name="forecastStr">
        ///     The forecast str.
        /// </param>
        public ForecastParser(string forecastStr)
        {
            this.RawForecasString = forecastStr;
        }

        /// <summary>
        ///     Gets or sets the forecast.
        /// </summary>
        public string RawForecasString { get; set; }

        /// <summary>
        /// The parse forecast.
        /// </summary>
        /// <param name="weatherDataFormat">
        /// The weather Data Format.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public Forecast ParseForecast(WeatherDataFormat weatherDataFormat)
        {
            switch (weatherDataFormat)
            {
                case WeatherDataFormat.Json:
                    return this.ParseJsonForecast();
                    break;
                case WeatherDataFormat.Xml:
                    throw new NotImplementedException();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(weatherDataFormat), weatherDataFormat, null);
            }
        }

        /// <summary>
        /// The parse json forecast.
        /// </summary>
        /// <returns>
        /// The <see cref="Forecast"/>.
        /// </returns>
        private Forecast ParseJsonForecast()
        {
            dynamic doc = JObject.Parse(this.RawForecasString);

            var temp = doc.main.temp;
            var hum = doc.main.humidity;
            var forecast = new Forecast() { Humidity = hum };
            forecast.SetTemp(Convert.ToDouble(temp), TemperatureUnit.Kelvin);

            return forecast;
        }
    }
}