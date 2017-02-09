namespace ArduinoDisplay.CLI
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using ArduinoDisplay.Core;
    using ArduinoDisplay.PluginInterface;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The bs.
        /// </summary>
        private static Bootstraper bs;

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            bs = new Bootstraper();
            bs.Start();
            try
            {
                var t = ConsoleSampleClient();
                t.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exit due to Exception: {0}", e.Message);
            }
        }

        /// <summary>
        /// The console sample client.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private static async Task ConsoleSampleClient()
        {
            foreach (var arduinoDisplayPlugin in bs.Plugins)
            {
                arduinoDisplayPlugin.Init();
                arduinoDisplayPlugin.Start();
                arduinoDisplayPlugin.DataReady += ValueDataReady;
            }

            Console.WriteLine("Monitor is running...Press any key to exit...");
            Console.ReadKey(true);
        }

        private static void ValueDataReady(object sender, DataReadyEventArgs e)
        {
            Console.WriteLine(e.NewData);
        }
    }
}