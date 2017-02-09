namespace ArduinoDisplay.WeatherPlugin
{
    using System;

    /// <summary>
    ///     The forecast.
    /// </summary>
    public class Forecast
    {
        private double temperatureF0;

        /// <summary>
        ///     Gets or sets the humidity.
        /// </summary>
        public double Humidity { get; set; }

        /// <summary>
        ///     Gets or sets the pressure.
        /// </summary>
        public double Pressure { get; set; }

        /// <summary>
        /// Gets the temperature c.
        /// </summary>
        public double TemperatureC { get; private set; }

        /// <summary>
        /// Gets or sets the temperature f.
        /// </summary>
        public double TemperatureF { get; set; }

        /// <summary>
        /// Gets or sets the temperature k.
        /// </summary>
        public double TemperatureK { get; set; }

        /// <summary>
        /// The set temp.
        /// </summary>
        /// <param name="val">
        /// The val.
        /// </param>
        /// <param name="units">
        /// The units.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public void SetTemp(double val, TemperatureUnit units = TemperatureUnit.Celsius)
        {
            switch (units)
            {
                case TemperatureUnit.Celsius:
                    this.TemperatureC = val;
                    this.TemperatureK = (this.TemperatureC - 32) / 1.8;
                    this.TemperatureK = (this.TemperatureC - 32) / 1.8;
                    break;
                case TemperatureUnit.Kelvin:
                    this.TemperatureK = val;
                    this.TemperatureC = val - 273.15;
                    this.TemperatureF = this.TemperatureC * 1.8 + 32;
                    break;
                case TemperatureUnit.Farenheit:
                    this.TemperatureF = val;
                    this.TemperatureC = (val - 32) / 1.8;
                    this.TemperatureK = this.TemperatureC + 273.15;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(units), units, null);
            }
        }
    }
}