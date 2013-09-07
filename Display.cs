using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace OrbitalHWMonitor
{
    class Display
    {
        //clear screen command sequence
        byte[] clear_screen = new byte[2] {254, 88};

        SerialPort port = new SerialPort();

        public Display(string portName, int baudRate)
        {
            
            port.PortName = portName;
            port.BaudRate = baudRate;
            port.DataBits = 8;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
        }

        public void Write(string text)
        {
            ClearScreen();
            port.Open();
            System.Text.ASCIIEncoding encoding = new ASCIIEncoding();
            port.Write(encoding.GetBytes(text), 0, encoding.GetByteCount(text));
            port.Close();
        }

        public void ClearScreen()
        {
            //Open port
            port.Open();    
            //Send clear screen command to display
            port.Write(clear_screen, 0, clear_screen.Length);
            port.Close();
        }


    }
}
