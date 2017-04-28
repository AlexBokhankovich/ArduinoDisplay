using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoDisplay.Display
{
    using System.Globalization;

    class Program
    {
        static void Main(string[] args)
        {
            var adruDisplay = new ArDisplay(DisplayType.HD44780_20X4, 7, 115000);
            adruDisplay.
        }

        public static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}