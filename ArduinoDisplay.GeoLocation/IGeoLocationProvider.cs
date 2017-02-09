namespace ArduinoDisplay.GeoLocation
{
    using ArduinoDisplay.GeoCommon;

    /// <summary>
    /// The GeoLocationProvider interface.
    /// </summary>
    internal interface IGeoLocationProvider
    {
        /// <summary>
        /// Gets the city.
        /// </summary>
        string City { get; }

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        Coordinate Coordinate { get; }
    }
}