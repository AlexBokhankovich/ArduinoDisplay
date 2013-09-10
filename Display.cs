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
    class Display
    {
        //display dimensions
        #region dimensions

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

        //clear screen command sequence
        const byte init_byte = 254;
        const byte cls_byte = 88;
        const byte set_cursor_byte = 71;
        public char[,] currentState = new char[columns, rows];

        SerialPort port = new SerialPort();

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
        /// <param name="text"></param>
        public void Write(string text)
        {
            System.Text.ASCIIEncoding encoding = new ASCIIEncoding();
            port.Write(encoding.GetBytes(text), 0, encoding.GetByteCount(text));
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

        public void ClearScreen()
        {
            byte[] cls = new byte[2] { init_byte, cls_byte };

            //Send clear screen command to display
            port.Write(cls, 0, cls.Length);
        }

        public void ClosePort()
        {
            port.Close();
        }

    }
}
