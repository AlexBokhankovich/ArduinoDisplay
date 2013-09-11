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


                display.ClearScreen();
                Info info = new Info();

                while (true)
                {
                    string cpuLoad =info.Time() +" " + info.GetCPULoad();
                    char[,] tempState = new char[display.Columns, display.Rows];
                    for (int i = 1; i <= cpuLoad.Length; i++)
                    {
                        tempState[i, 1] = cpuLoad[i - 1];
                    }
                    Thread.Sleep(500);
                    Console.Clear();
                    for (int i = 1; i < display.Columns; i++)
                    {
                        if (tempState[i, 1] != display.currentState[i, 1])
                        {
                            display.SetCursorPosition(i, 1);
                            display.Write(tempState[i, 1]);
                            display.currentState[i, 1] = tempState[i, 1];
                            
                        }
                        Console.Write(display.currentState[i, 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message + "\n" + "Stack:" + ex.StackTrace);
            }


            //while (1 > 0)
            //{
            //    display.Write(Info.Time());
            //    Thread.Sleep(1000);
            //}

            Console.ReadKey();
            //display.ClosePort();
        }
    }
}
