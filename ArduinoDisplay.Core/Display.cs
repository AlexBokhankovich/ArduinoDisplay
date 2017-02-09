#region

#endregion

namespace OrbitalHWMonitor
{
    using System;
    using System.IO.Ports;
    using System.Text;

    /// <summary>
    ///     Represents display class
    /// </summary>
    internal class Display : IDisposable
    {
        private const byte ClsByte = 88; //clear screen byte

        private const byte columns = 20;

        private const byte InitByte = 254; //tells Matrix Orbital display next bytes are commands and parameters

        private const byte rows = 4;

        private const byte SetCursorByte = 71; //set cursor byte

        public char[,] CurrentState = new char[columns, rows];

        private readonly SerialPort port = new SerialPort();

        /// <summary>
        ///     Class constructor
        /// </summary>
        /// <param name="portName">port display connected to</param>
        /// <param name="baudRate">port speed</param>
        public Display(string portName, int baudRate)
        {
            this.port.PortName = portName;
            this.port.BaudRate = baudRate;
            this.port.DataBits = 8;
            this.port.Parity = Parity.None;
            this.port.StopBits = StopBits.One;
            this.port.Open();
        }

        public byte Columns => columns;

        public byte Rows => rows;

        /// <summary>
        ///     Clears the display
        /// </summary>
        public void ClearScreen()
        {
            var cls = new byte[2] { InitByte, ClsByte };
            this.port.Write(cls, 0, cls.Length);
        }

        /// <summary>
        ///     Closes display port
        /// </summary>
        public void ClosePort()
        {
            this.port.Close();
        }

        public void Dispose()
        {
            this.ClosePort();
        }

        /// <summary>
        ///     Sets the cursor to the desired position
        /// </summary>
        /// <param name="column">Column number to move cursor to</param>
        /// <param name="row">Row number to move cursor to</param>
        public void SetCursorPosition(int column, int row)
        {
            var cursorPosition = new[] { InitByte, SetCursorByte, (byte)column, (byte)row };
            this.port.Write(cursorPosition, 0, cursorPosition.Length);
        }

        /// <summary>
        ///     Writes text to the current cursor position
        /// </summary>
        /// <param name="text">text to display</param>
        public void Write<T>(T text)
        {
            var encoding = new ASCIIEncoding();
            this.port.Write(encoding.GetBytes(text.ToString()), 0, encoding.GetByteCount(text.ToString()));
        }

        internal void WriteLine(string text, int line)
        {
            var differ = false;
            if (text.Length > this.Columns) text = text.Substring(0, this.Columns);
            //define temporary storage for line state
            var tempState = new char[this.Columns];
            //fill temp array with given string
            tempState = text.ToCharArray();
            //check if current symbol is different from the symbol we want write
            //and if it is send it to display
            for (var i = 1; i <= this.Columns; i++)
            {
                if (tempState.Length >= i && tempState[i - 1] != this.CurrentState[i - 1, line - 1])
                {
                    differ = true;
                    this.SetCursorPosition(i, line);
                    this.Write(tempState[i - 1]);
                    this.CurrentState[i - 1, line - 1] = tempState[i - 1];
                }
                //if text has changed and text string length less than display length 
                //then draw blanks up to display line end
                if (differ && tempState.Length < this.Columns)
                {
                    this.SetCursorPosition(tempState.Length + 1, line);
                    for (var j = tempState.Length + 1; j <= this.Columns; j++) this.Write(' ');
                }
                //always draw blanks
                if (differ && tempState.Length >= i && tempState[i - 1] == ' ')
                {
                    this.SetCursorPosition(i, line);
                    this.Write(' ');
                }
            }
        }

        /// <summary>
        ///     Writes a text string on display.
        ///     Trims string to match columns count
        /// </summary>
        /// <param name="textLine">String to display</param>
        /// <param name="lineNumber">line number to display string at</param>
        internal void WriteLine2(string textLine, int lineNumber)
        {
            //SetCursorPosition(1, 1);
            Console.WriteLine();

            if (textLine.Length > this.Columns) textLine = textLine.Substring(0, this.Columns);
            var tempState = new char[this.Columns, this.Rows];
            for (var i = lineNumber; i <= textLine.Length; i++) tempState[i, lineNumber] = textLine[i - lineNumber];
            for (var i = 1; i < this.Columns; i++)
                if (tempState[i, lineNumber] != this.CurrentState[i, lineNumber])
                {
                    this.SetCursorPosition(i, lineNumber);
                    this.Write(tempState[i, lineNumber]);
                    this.CurrentState[i, lineNumber] = tempState[i, lineNumber];
                    //TODO: this is for debugging only. Writes changed data in green color
                    var backColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(this.CurrentState[i, lineNumber]);
                    Console.ForegroundColor = backColor;
                }
                //TODO: this is for debugging only. See above comment
                else
                {
                    Console.Write(this.CurrentState[i, lineNumber]);
                }
        }
    }
}