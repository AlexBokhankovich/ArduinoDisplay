namespace ArduinoDisplay.DateTimePlugin
{
    using System;

    using ArduinoDisplay.PluginInterface;

    /// <summary>
    ///     The date time provider.
    /// </summary>
    public class DateTimeProvider : IDataProvider<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeProvider"/> class.
        /// </summary>
        /// <param name="format">
        ///     The format.
        /// </param>
        public DateTimeProvider(string format)
        {
            this.Format = format;
        }

        /// <summary>
        ///     Gets the format.
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// The value.
        /// </summary>
        public string Value => this.GetValue();

        /// <summary>
        /// The get value.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetValue()
        {
            return DateTime.Now.ToString(this.Format);
        }
    }
}