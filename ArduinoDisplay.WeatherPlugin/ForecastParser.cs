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
        ///     The parse forecast.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public Forecast ParseForecast()
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