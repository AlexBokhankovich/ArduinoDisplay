using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OrbitalHWMonitor
{
    class SysDiag
    {       
        private static PerformanceCounter counter;
               
        public SysDiag()
        {
            counter = new PerformanceCounter();
            counter.CategoryName = "Processor";
            counter.CounterName = "% Processor Time";
            counter.InstanceName = "_Total";
        }
        public string getCurrentCpuUsage()
        {
            return string.Format(@"CPU:{0:000}%",counter.NextValue());
        }
    }
}
