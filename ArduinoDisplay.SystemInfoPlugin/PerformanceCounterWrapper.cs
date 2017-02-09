namespace ArduinoDisplay.SystemInfoPlugin
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    /// <summary>
    /// The performance counter wrapper.
    /// </summary>
    public class PerformanceCounterWrapper
    {
        /// <summary>
        ///     The counter.
        /// </summary>
        private readonly PerformanceCounter counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemDiagnostic"/> class.
        /// </summary>
        /// <param name="categoryName">
        /// The category name.
        /// </param>
        /// <param name="counterName">
        /// The counter name.
        /// </param>
        /// <param name="instanceName">
        /// The instance name.
        /// </param>
        public PerformanceCounterWrapper(string categoryName, string counterName, string instanceName = null)
        {
            this.counter = new PerformanceCounter(categoryName, counterName, instanceName);
            this.CategoryName = categoryName;
            this.CounterName = counterName;
            this.InstanceName = instanceName;

        }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the counter name.
        /// </summary>
        public string CounterName { get; set; }

        /// <summary>
        /// Gets or sets the instance name.
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// The get current value.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetCurrentValue()
        {
            var val = counter.NextValue();
            return Math.Round(val).ToString(CultureInfo.InvariantCulture);
        }
    }
}