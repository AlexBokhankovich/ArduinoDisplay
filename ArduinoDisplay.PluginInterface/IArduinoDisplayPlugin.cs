namespace ArduinoDisplay.PluginInterface
{
    using System;

    /// <summary>
    ///     The ArduinoPlugin interface.
    /// </summary>
    public interface IArduinoDisplayPlugin
    {
        /// <summary>
        ///     The data ready.
        /// </summary>
        event EventHandler<DataReadyEventArgs> DataReady;

        /// <summary>
        ///     Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     The init.
        /// </summary>
        void Init();

        /// <summary>
        ///     The start.
        /// </summary>
        void Start();

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        void Configure(dynamic config);
    }
}