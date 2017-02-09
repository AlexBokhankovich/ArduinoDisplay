namespace OrbitalHWMonitor
{
    using System;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Threading;

    internal class NetworkInfo
    {
        internal static long BytesReceived;

        internal static long BytesSent;

        internal static string ethText;

        internal static long WlanBytesReceived;

        internal static long WlanBytesSent;

        internal static string wlanText;

        private static double downSpeed;

        private static double upSpeed;

        private static double wlanDownSpeed;

        private static double wlanUpSpeed;

        public static double DownSpeed => Math.Round(downSpeed, 2);

        public static string EthText => ethText;

        public static double UpSpeed => Math.Round(upSpeed, 2);

        public static double WlanDownSpeed => Math.Round(wlanDownSpeed, 2);

        public static string WlanText => wlanText;

        public static double WlanUpSpeed => Math.Round(wlanUpSpeed, 2);

        public void Temperature()
        {
            while (true)
            {
                // Forecast.ParseForecast();
                Thread.Sleep(TimeSpan.FromMinutes(15));
            }
        }

        internal void Init()
        {
            while (true)
            {
                this.UpdateStats();
                Thread.Sleep(1000);
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            this.UpdateStats();
        }

        private void UpdateStats()
        {
            var interfaces = NetworkInterface.GetAllNetworkInterfaces();

            var ethernet =
                interfaces.FirstOrDefault(
                    ni =>
                        ni.Description.ToLowerInvariant().Contains("Realtek PCIe GBE".ToLowerInvariant())
                        && ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                        && ni.Name.ToLowerInvariant().Contains("ethernet")
                        && ni.OperationalStatus == OperationalStatus.Up);

            if (ethernet != null)
            {
                var interfaceStats = ethernet.GetIPv4Statistics();

                double upSpeedTmp = (interfaceStats.BytesSent - BytesSent) / 1024; // *1024);
                double downSpeedTmp = (interfaceStats.BytesReceived - BytesReceived) / 1024; // * 1024);

                // TODO: fff
                // var forecast = new Forecast().ParseForecast();
                if (upSpeedTmp.ToString().Length >= 3 || downSpeedTmp.ToString().Length >= 3)
                {
                    upSpeed = upSpeedTmp / 1024;
                    downSpeed = downSpeedTmp / 1024;
                    ethText = "MBps";
                }
                else
                {
                    upSpeed = upSpeedTmp;
                    downSpeed = downSpeedTmp;
                    ethText = "KBps";
                }

                BytesReceived = interfaceStats.BytesReceived;
                BytesSent = interfaceStats.BytesSent;
            }

            var wifi = interfaces.FirstOrDefault(
                ni => ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211

                      // && ni.Name.ToLowerInvariant().Contains("ethernet")
                      && ni.OperationalStatus == OperationalStatus.Up);

            if (wifi != null)
            {
                var interfaceStats = wifi.GetIPv4Statistics();

                double wlanUpSpeedTmp = (interfaceStats.BytesSent - WlanBytesSent) / 1024; // *1024);
                double wlanDownSpeedTmp = (interfaceStats.BytesReceived - WlanBytesReceived) / 1024; // * 1024);

                WlanBytesReceived = interfaceStats.BytesReceived;
                WlanBytesSent = interfaceStats.BytesSent;

                if (wlanUpSpeedTmp.ToString().Length >= 3 || wlanDownSpeedTmp.ToString().Length >= 3)
                {
                    wlanUpSpeed = wlanUpSpeedTmp / 1024;
                    wlanDownSpeed = wlanDownSpeedTmp / 1024;
                    wlanText = "MBps";
                }
                else
                {
                    wlanUpSpeed = wlanUpSpeedTmp;
                    wlanDownSpeed = wlanDownSpeedTmp;
                    wlanText = "KBps";
                }
            }
        }
    }
}