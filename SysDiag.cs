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

        public string CategoryName { get; set; }
        public string CounterName { get; set; }
        public string InstanceName { get; set; }


        public SysDiag(string CategoryName, string CounterName, string InstanceName=null)
        {
            counter = new PerformanceCounter();
            counter.CategoryName = CategoryName;
            counter.CounterName = CounterName;
            counter.InstanceName = InstanceName;
        }
        public string getCurrentValue()
        {
            return Math.Round((double)counter.NextValue()).ToString();
        }
    }
}
