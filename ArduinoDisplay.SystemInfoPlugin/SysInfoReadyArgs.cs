namespace ArduinoDisplay.SystemInfoPlugin
{
    using System;

    /// <summary>
    /// The sys info ready args.
    /// </summary>
    public class SysInfoReadyArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SysInfoReadyArgs"/> class.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public SysInfoReadyArgs(string data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public string Data { get; set; }
    }
}