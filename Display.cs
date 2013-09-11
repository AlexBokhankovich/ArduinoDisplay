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
        /// <param name="row">row number to move cursor to</param>
        public void SetCursorPosition(int column, int row)
        {
            byte[] cursor_position = new byte[4] { init_byte, set_cursor_byte, (byte)column, (byte)row };
            port.Write(cursor_position, 0, cursor_position.Length);
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
