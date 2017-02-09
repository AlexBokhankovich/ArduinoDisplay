namespace ArduinoDisplay.PluginInterface
{
    using System;
    using System.Threading;

    /// <summary>
    /// The generic updater.
    /// </summary>
    /// <typeparam name="TEvtArgs">
    /// Event args
    /// </typeparam>
    public abstract class GenericUpdater<TEvtArgs, TProvValueType> : IUpdater<TEvtArgs, TProvValueType>
        where TEvtArgs : EventArgs where TProvValueType : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericUpdater{TEvtArgs,TProvValueType}"/> class.
        /// </summary>
        /// <param name="updateFreq">
        /// The update freq.
        /// </param>
        protected GenericUpdater(IDataProvider<TProvValueType> prov, int updateFreq)
        {
            this.Provider = prov;
            this.UpdateFrequency = updateFreq;
        }

        /// <summary>
        /// The data ready.
        /// </summary>
        public event EventHandler<TEvtArgs> DataReady;

        /// <summary>
        /// Gets the provider.
        /// </summary>
        public IDataProvider<TProvValueType> Provider { get; }

        /// <summary>
        /// Gets or sets the update frequency.
        /// </summary>
        public int UpdateFrequency { get; set; }

        /// <summary>
        /// Gets or sets the timer.
        /// </summary>
        private Timer Timer { get; set; }

        /// <summary>
        /// The start.
        /// </summary>
        public void Start()
        {
            this.Timer = new Timer(this.OnTimerElapsed, null, 3000, this.UpdateFrequency);
        }

        /// <summary>
        /// The stop.
        /// </summary>
        public void Stop()
        {
            this.Timer.Dispose();
        }

        /// <summary>
        /// The on timer elapsed.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected virtual void InvokeDataReadyEvent(TEvtArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            var handler = this.DataReady;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// The on timer elapsed.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        protected abstract void OnTimerElapsed(object state);
    }
}