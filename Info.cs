using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalHWMonitor
{
    class Info
    {
        public string CPUUsage
        { get { return GetCPULoad(); } }

        public string RAMFree
        { get { return GetRAMAvailable(); } }

        public string TimeWithSec
        { get { return GetTime(); } }

        public string TimeWithoutSec
        { get { return GetTime(false); } }

        public string GetTime(bool showSec = true)
        {
            string timePat = string.Empty;

            if (showSec)
                timePat = @"hh:mm:ss";
            else
                timePat = @"hh:mm";
            return DateTime.Now.ToString(timePat);
        }
        SysDiag counter = new SysDiag("Processor", "% Processor Time", InstanceName: "_Total");
        public string GetCPULoad()
        {
            counter.CategoryName = "Processor";
            counter.CounterName = "% Processor Time";
            counter.InstanceName = "_Total";
            var temp = counter.getCurrentValue();
            if (temp.Length == 3)
                return temp;
            if (temp.Length == 2)
                return " " + temp;
            else
                return " " + " " + temp;


        }

        public string GetRAMAvailable()
        {
            counter.CategoryName = "Memory";
            counter.CounterName = "Available MBytes";
            counter.InstanceName = string.Empty;

            return String.Format(counter.getCurrentValue());
        }
    }
}
