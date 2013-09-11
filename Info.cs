using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalHWMonitor
{
    class Info
    {
        public string Time(bool showSec = true)
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
            return String.Format("CPU:" + counter.getCurrentValue() + "%");
        }

        public string GetRAMUsage()
        {
            counter.CategoryName = "Memory";
            counter.CounterName = "Available MBytes";
            counter.InstanceName = string.Empty;
            return String.Format(counter.getCurrentValue());
        }
    }
}
