namespace ArduinoDisplay.PluginInterface
{
    /// <summary>
    /// The DataProvider interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IDataProvider<T>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        T Value { get; }
    }
}