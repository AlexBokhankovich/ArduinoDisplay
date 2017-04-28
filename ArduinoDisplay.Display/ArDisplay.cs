namespace ArduinoDisplay.Display
{
    using System;
    using System.IO.Ports;
    using ArduinoDisplay.DisplayInterface;
    using ArduinoDisplay.HD44780;

    /// <summary>
    /// The ar display.
    /// </summary>
    public class ArDisplay
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArDisplay"/> class.
        /// </summary>
        /// <param name="displayType">
        /// The display type.
        /// </param>
        /// <param name="portNumber">
        /// The port number.
        /// </param>
        /// <param name="portSpeed">
        /// The port speed.
        /// </param>
        public ArDisplay(DisplayType displayType, int portNumber, int portSpeed)
        {
            this.DisplayType = displayType;

            switch (displayType)
            {
                case DisplayType.HD44780_16X2:
                    this.Display = new Hd44780Display(16, 2);
                    break;
                case DisplayType.HD44780_16X4:
                    this.Display = new Hd44780Display(16, 4);
                    break;
                case DisplayType.HD44780_20X2:
                    this.Display = new Hd44780Display(20, 2);
                    break;
                case DisplayType.HD44780_20X4:
                    this.Display = new Hd44780Display(20, 4);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(displayType), displayType, null);
            }
            
        }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public SerialPort Port { get; set; }

        /// <summary>
        /// Gets the display instance.
        /// </summary>
        public IDisplay Display { get; }

        /// <summary>
        /// Gets the display type.
        /// </summary>
        public DisplayType DisplayType { get; }

        /// <summary>
        /// Gets the port number.
        /// </summary>
        public int PortNumber { get; }

        /// <summary>
        /// Gets the port speed.
        /// </summary>
        public int PortSpeed { get; }
    }
}