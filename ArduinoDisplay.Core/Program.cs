namespace OrbitalHWMonitor
{
    using System.Threading;

    using ArduinoDisplay.Core;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // try
            // {
            var display = new Display("COM3", 19200);
            var asyncInfo = new NetworkInfo();
            var t = new Thread(asyncInfo.Init);
            t.Start();

            var temperature = new Thread(asyncInfo.Temperature);
            temperature.Start();

            // Clear display twice. IDK why it doesn't get clear after one pass
            display.ClearScreen();
            for (var i = 1; i <= display.Columns; i++) for (var j = 1; j <= display.Rows; j++) display.CurrentState[i - 1, j - 1] = ' ';

            Thread.Sleep(500);
            display.ClearScreen();

            var info = new { TimeWithSec  = 3, CpuUsage = 3};

            while (true)
            {
                // Console.Clear();
                var textLine = info.TimeWithSec + " " + "CPU:" + info.CpuUsage + "%";
                display.WriteLine(textLine, 1);

                var textLine2 = @"ETH: " + NetworkInfo.DownSpeed + @"/" + NetworkInfo.UpSpeed + " " + NetworkInfo.EthText;
                var textLine3 = @"WLAN: " + NetworkInfo.WlanDownSpeed + "/" + NetworkInfo.WlanUpSpeed + " "
                                + NetworkInfo.WlanText;
                display.WriteLine(textLine2, 2);
                display.WriteLine(textLine3, 3);

                // display.WriteLine("Ivanovo:" + Weather.Temperature, 4);
                Thread.Sleep(500);
            }
        }
    }
}