namespace ArduinoDisplay.SystemInfoPlugin.OhwMonitor
{
    using System.Collections.Generic;

    using OpenHardwareMonitor.Hardware;

    /// <summary>
    /// The hardware comparer.
    /// </summary>
    public class HardwareComparer : IComparer<IHardware>
    {
        public int Compare(IHardware x, IHardware y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;

            if (x.HardwareType != y.HardwareType)
                return x.HardwareType.CompareTo(y.HardwareType);

            return x.Identifier.CompareTo(y.Identifier);
        }
    }
}