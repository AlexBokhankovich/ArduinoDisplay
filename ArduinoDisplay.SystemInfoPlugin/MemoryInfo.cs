namespace ArduinoDisplay.SystemInfoPlugin
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// The memory info.
    /// </summary>
    public class MemoryInfo
    {
        /// <summary>
        /// The get system memory division.
        /// </summary>
        /// <param name="lpdwStorePages">
        /// The lpdw store pages.
        /// </param>
        /// <param name="lpdwRamPages">
        /// The lpdw ram pages.
        /// </param>
        /// <param name="lpdwPageSize">
        /// The lpdw page size.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [DllImport("kernel32.dll")]
        public static extern int GetSystemMemoryDivision(
            ref uint lpdwStorePages,
            ref uint lpdwRamPages,
            ref uint lpdwPageSize);

        /// <summary>
        /// The global memory status.
        /// </summary>
        /// <param name="lpBuffer">
        /// The lp buffer.
        /// </param>
        [DllImport("kernel32.dll")]
        public static extern void GlobalMemoryStatus(ref MEMORYSTATUS lpBuffer);

        /// <summary>
        /// The show memory.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ShowMemory()
        {
            uint storePages = 0;
            uint ramPages = 0;
            uint pageSize = 0;

            // var res = GetSystemMemoryDivision(ref storePages, ref ramPages, ref pageSize);

            // Call the native GlobalMemoryStatus method
            // with the defined structure.
            var memStatus = new MEMORYSTATUS();
            GlobalMemoryStatus(ref memStatus);

            var memoryInfo = new StringBuilder();
            memoryInfo.Append("Memory Load: " + memStatus.dwMemoryLoad + "\n");
            memoryInfo.Append("Total Physical: " + memStatus.dwTotalPhys + "\n");
            memoryInfo.Append("Avail Physical: " + memStatus.dwAvailPhys + "\n");
            memoryInfo.Append("Total Page File: " + memStatus.dwTotalPageFile + "\n");
            memoryInfo.Append("Avail Page File: " + memStatus.dwAvailPageFile + "\n");
            memoryInfo.Append("Total Virtual: " + memStatus.dwTotalVirtual + "\n");
            memoryInfo.Append("Avail Virtual: " + memStatus.dwAvailVirtual + "\n");
            return memoryInfo.ToString();
        }

        /// <summary>
        /// The memorystatus.
        /// </summary>
        public struct MEMORYSTATUS
        {
            public uint dwLength;

            public uint dwMemoryLoad;

            public uint dwTotalPhys;

            public uint dwAvailPhys;

            public uint dwTotalPageFile;

            public uint dwAvailPageFile;

            public uint dwTotalVirtual;

            public uint dwAvailVirtual;
        }
    }
}