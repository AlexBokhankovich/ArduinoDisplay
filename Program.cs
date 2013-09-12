using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OrbitalHWMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Display display = new Display("COM3", 19200);

                //Clear display twice. IDK why it doesn't get clear after one pass
                display.ClearScreen();
                display.ClearScreen();

                Info info = new Info();

                while (true)
                {
                    Console.Clear();
                    string textLine = info.TimeWithSec + " " + "CPU:" + info.CPUUsage + "%";
                    display.WriteLine(textLine, 1);
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message + "\n" + "Stack:" + ex.StackTrace);
            }
            Console.ReadKey();
        }


    }
}
