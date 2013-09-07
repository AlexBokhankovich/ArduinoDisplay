using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalHWMonitor
{
    class Info
    {
        public static string Time(bool showSec = true)
        {
            string timePat = string.Empty;

            if (showSec)
                timePat = @"hh:mm:ss";
            else
                timePat = @"hh:mm";
            return DateTime.Now.ToString(timePat);
        }
    }
}
