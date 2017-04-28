namespace ArduinoDisplay.DisplayInterface
{
    /// <summary>
    /// The CommunicationProtocol interface.
    /// </summary>
    /// <typeparam name="T">
    /// Resulting type
    /// </typeparam>
    public interface ICommunicationProtocol<T>
    {
        /// <summary>
        /// The prepare data.
        /// </summary>
        /// <param name="strData">
        /// Data as string
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T PrepareData(string strData);
    }
}