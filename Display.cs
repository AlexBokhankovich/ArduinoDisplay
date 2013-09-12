using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace OrbitalHWMonitor
{
    /// <summary>
    /// Represents display class
    /// </summary>
    class Display : IDisposable
    {
        #region display dimensions

        const byte rows = 4;
        const byte columns = 20;

        public byte Rows
        {
            get { return rows; }
        }

        public byte Columns
        {
            get { return columns; }
        }
        #endregion
        #region control bytes
        const byte init_byte = 254; //tells Matrix Orbital display next bytes are commands and parameters
        const byte cls_byte = 88; //clear screen byte
        const byte set_cursor_byte = 71; //set cursor byte
        #endregion

        public char[,] currentState = new char[columns, rows];

        SerialPort port = new SerialPort();

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="portName">port display connected to</param>
        /// <param name="baudRate">port speed</param>
        public Display(string portName, int baudRate)
        {
            port.PortName = portName;
            port.BaudRate = baudRate;
            port.DataBits = 8;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.Open();
        }
        /// <summary>
        /// Writes text to the current cursor position
        /// </summary>
        /// <param name="text">text to display</param>
        public void Write<T>(T text)
        {
            System.Text.ASCIIEncoding encoding = new ASCIIEncoding();
            port.Write(encoding.GetBytes(text.ToString()), 0, encoding.GetByteCount(text.ToString()));
        }
        /// <summary>
        /// Sets the cursor to the desired position
        /// </summary>
        /// <param name="column">Column number to move cursor to</param>
        /// <param name="row">Row number to move cursor to</param>
        public void SetCursorPosition(int column, int row)
        {
            byte[] cursor_position = new byte[4] { init_byte, set_cursor_byte, (byte)column, (byte)row };
            port.Write(cursor_position, 0, cursor_position.Length);
        }

        /// <summary>
        /// Writes a text string on display. 
        /// Trims string to match columns count
        /// </summary>
        /// <param name="textLine">String to display</param>
        /// <param name="lineNumber">line number to display string at</param>
        internal void WriteLine(string textLine, int lineNumber)
        {
            Console.WriteLine();

            if (textLine.Length > Columns)
            {
                textLine = textLine.Substring(0, Columns);
            }
            char[,] tempState = new char[Columns, Rows];
            for (int i = lineNumber; i <= textLine.Length; i++)
            {
                tempState[i, lineNumber] = textLine[i - lineNumber];
            }
            for (int i = 1; i < Columns; i++)
            {
                if (tempState[i, lineNumber] != currentState[i, lineNumber])
                {
                    SetCursorPosition(i, lineNumber);
                    Write(tempState[i, lineNumber]);
                    currentState[i, lineNumber] = tempState[i, lineNumber];
                    //TODO: this is for debugging only. Writes changed data in green color
                    ConsoleColor backColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(currentState[i, lineNumber]);
                    Console.ForegroundColor = backColor;
                }
                    //TODO: this is for debugging only. See above comment
                else
                    Console.Write(currentState[i, lineNumber]);
            }
        }

        /// <summary>
        /// Clears the display
        /// </summary>
        public void ClearScreen()
        {
            byte[] cls = new byte[2] { init_byte, cls_byte };
            port.Write(cls, 0, cls.Length);
        }

        /// <summary>
        /// Closes display port
        /// </summary>
        public void ClosePort()
        {
            this.port.Close();
        }


        public void Dispose()
        {
            ClosePort();
        }
    }
}
