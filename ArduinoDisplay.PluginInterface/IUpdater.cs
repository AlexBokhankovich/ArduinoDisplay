namespace ArduinoDisplay.PluginInterface
{
    using System;

    /// <summary>
    /// The Updater interface.
    /// </summary>
    /// <typeparam name="TEvtArgs">
    /// </typeparam>
    public interface IUpdater<TEvtArgs, TProvValueType>
        where TEvtArgs : EventArgs
    {
        /// <summary>
        /// The data ready.
        /// </summary>
        event EventHandler<TEvtArgs> DataReady;

        /// <summary>
        /// Gets the provider.
        /// </summary>
        IDataProvider<TProvValueType> Provider { get; }

        /// <summary>
        /// Gets or sets the update frequency.
        /// </summary>
        int UpdateFrequency { get; set; }

        /// <summary>
        /// The start.
        /// </summary>
        void Start();

        /// <summary>
        /// The stop.
        /// </summary>
        void Stop();
    }
}