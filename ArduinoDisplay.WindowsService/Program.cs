namespace ArduinoDisplay.WindowsService
{
    using System;
    using System.ServiceProcess;

    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        private static void Main()
        {

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var servicesToRun = new ServiceBase[] { new ArduinoDisplayService() };
            ServiceBase.Run(servicesToRun);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}