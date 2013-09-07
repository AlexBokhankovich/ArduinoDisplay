using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalHWMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Display display = new Display("COM3", 19200);
            display.Write("TEST");
            Console.ReadKey();
        }
    }
}
