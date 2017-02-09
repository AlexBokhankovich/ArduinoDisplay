namespace ArduinoDisplay.DateTimePlugin
{
    using System;

    /// <summary>
    ///     The date time event args.
    /// </summary>
    public class DateTimeEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DateTimeEventArgs" /> class.
        /// </summary>
        /// <param name="dic">
        ///     The dic.
        /// </param>
        public DateTimeEventArgs(string dic)
        {
            this.DateTime = dic;
        }

        /// <summary>
        ///     Gets or sets the date time.
        /// </summary>
        public string DateTime { get; set; }
    }
}