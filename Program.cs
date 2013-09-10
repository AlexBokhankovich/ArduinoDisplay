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
            Display display = new Display("COM3", 19200);

            display.ClearScreen();
            SysDiag counter = new SysDiag();

            while (true)
            {                
                string cpuLoad=counter.getCurrentCpuUsage();
                char[,] tempState=new char [display.Columns, display.Rows];
                for (int i=1; i<=cpuLoad.Length; i++)
                {
                    tempState[i,1]=cpuLoad[i-1];
                }
                Console.WriteLine(cpuLoad);
                Thread.Sleep(500);
                Console.Clear();
                for (int i=1; i<display.Columns;i++)
                {
                    if (tempState[i,1]!=display.currentState[i,1])
                    {
                        display.SetCursorPosition(i,1);
                        display.Write(tempState[i,1].ToString());
                        display.currentState[i,1]=tempState[i,1];                        
                    }
                }               
            }
            
            
            //while (1 > 0)
            //{
            //    display.Write(Info.Time());
            //    Thread.Sleep(1000);
            //}

            Console.ReadKey();
            display.ClosePort();
        }
    }
}
