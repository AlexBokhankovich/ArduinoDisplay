namespace ArduinoDisplay.DisplayInterface
{
    /// <summary>
    /// The Display interface.
    /// </summary>
    public interface IDisplay
    {
        void Clear();

        void Redraw();

        void SetCursor(int column, int row);

        int Rows { get; }

        int Columns { get; }
    }
}