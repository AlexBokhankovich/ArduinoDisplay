// ReSharper disable InconsistentNaming

namespace ArduinoDisplay.Display
{
    /// <summary>
    /// The display type.
    /// </summary>
    public enum DisplayType
    {
        /// <summary>
        /// HD44780 16 columns 2 rows
        /// </summary>
        HD44780_16X2 = 0,

        /// <summary>
        /// HD44780 16 columns 4 rows
        /// </summary>
        HD44780_16X4 = 1,

        /// <summary>
        /// HD44780 20 columns 2 rows
        /// </summary>
        HD44780_20X2,

        /// <summary>
        /// HD44780 16 columns 4 rows
        /// </summary>
        HD44780_20X4
    }
}