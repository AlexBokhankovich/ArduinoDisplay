namespace ArduinoDisplay.HD44780
{
    #region

    using System;
    using System.IO.Ports;

    using ArduinoDisplay.DisplayInterface;
    using ArduinoDisplay.MatrixOrbitalProtocol;

    #endregion

    /// <summary>
    ///     The hd 44780 display.
    /// </summary>
    public class Hd44780Display : IDisplay
    {
        private int DataBits = 8;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hd44780Display"/> class.
        /// </summary>
        /// <param name="rows">
        /// The rows.
        /// </param>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <param name="port">
        /// The port.
        /// </param>
        /// <param name="speed">
        /// The speed.
        /// </param>
        public Hd44780Display(int rows, int columns, int portNumber, int portSpeed)
        {
            this.Rows = rows;
            this.Columns = columns;

            this.Protocol = new MatrixOrbitalProtocol();

            this.PortNumber = portNumber;
            this.PortSpeed = portSpeed;

            this.InternalData = new string[rows];
            for (var i = 0; i < rows; i++)
            {
                this.InternalData[i] = string.Empty;
            }

            this.Port = new SerialPort()
            {
                BaudRate = this.PortSpeed,
                DataBits = 8,
                PortName = $"COM{this.PortNumber}",
                Parity = Parity.None,
                StopBits = StopBits.One
            };
            this.Port.Open();
        }

        private bool IsRowChanged(int row, string newRowValue)
        {
            return newRowValue.Equals(this.InternalData[row]);
        }

        public string[] InternalData { get; set; }

        public SerialPort Port { get; set; }

        public int PortSpeed { get; set; }

        public int PortNumber { get; set; }

        /// <summary>
        /// Gets the protocol.
        /// </summary>
        private ICommunicationProtocol<ByteLengthWrapper> Protocol { get; }

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            var clearScreenCommand = new[] { (byte)Commands.Init, (byte)Commands.ClearScreen };
            this.Port.Write(clearScreenCommand, 0, clearScreenCommand.Length);
        }

        /// <summary>
        /// The redraw.
        /// </summary>
        public void Redraw()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The set cursor.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="row">
        /// The row.
        /// </param>
        public void SetCursor(int column, int row)
        {
            var cursorPosition = new[] { (byte)Commands.Init, (byte)Commands.SetCursorPosition, (byte)column, (byte)row };
            this.Port.Write(cursorPosition, 0, cursorPosition.Length);
        }

        /// <summary>
        /// Gets the rows.
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// Gets the columns.
        /// </summary>
        public int Columns { get; }
    }
}