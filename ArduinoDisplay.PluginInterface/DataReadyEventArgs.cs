namespace ArduinoDisplay.PluginInterface
{
    using System;

    /// <summary>
    ///     The my event args.
    /// </summary>
    public class DataReadyEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DataReadyEventArgs" /> class.
        /// </summary>
        /// <param name="data">
        ///     The data.
        /// </param>
        public DataReadyEventArgs(string data)
        {
            this.NewData = data;
        }

        /// <summary>
        ///     Gets or sets the new data.
        /// </summary>
        public string NewData { get; set; }
    }
}