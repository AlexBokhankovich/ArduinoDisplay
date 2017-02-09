namespace ArduinoDisplay.WeatherPlugin
{
    using System;

    /// <summary>
    /// The weather update event args.
    /// </summary>
    public class WeatherUpdateEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherUpdateEventArgs"/> class.
        /// </summary>
        /// <param name="dic">
        /// The dic.
        /// </param>
        public WeatherUpdateEventArgs(string dic)
        {
            this.Weather = dic;
        }

        /// <summary>
        /// Gets or sets the weather.
        /// </summary>
        public string Weather { get; set; }
    }
}