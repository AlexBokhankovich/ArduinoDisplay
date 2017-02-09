namespace ArduinoDisplay.SystemInfoPlugin.OhwMonitor
{
    using System.Collections.Generic;
    using System.Linq;

    using OpenHardwareMonitor.Hardware;

    /// <summary>
    /// The open hardware monitor wrapper.
    /// </summary>
    public class OpenHardwareMonitorWrapper
    {
        private readonly IDictionary<IHardware, IList<ISensor>> sensors =
            new SortedDictionary<IHardware, IList<ISensor>>(new HardwareComparer());

        private Computer computer;

        private ISensor sensor;

        private UpdateVisitor visitor;

        public OpenHardwareMonitorWrapper(HardwareType hwType, SensorType sensorType, string name)
        {
            var settings = new PersistentSettings();

            this.computer = new Computer(settings)
                                {
                                    MainboardEnabled = true,
                                    CPUEnabled = true,
                                    RAMEnabled = true,
                                    GPUEnabled = true,
                                    FanControllerEnabled = true,
                                    HDDEnabled = true
                                };
            this.visitor = new UpdateVisitor();
            this.computer.HardwareAdded += this.HardwareAdded;
            this.computer.Open();

            this.sensor =
                this.computer.Hardware.First(h => h.HardwareType == hwType)
                    .Sensors.First(s => s.SensorType == sensorType && (name == null || s.Name == name));

            // this.CpuUtilisationSensor =
            // this.Computer.Hardware.First(h => h.HardwareType == HardwareType.CPU)
            // .Sensors.First(s => s.SensorType == SensorType.Load && s.Name == "CPU Total");

            // this.CpuTemperatureSensor =
            // this.Computer.Hardware.First(h => h.HardwareType == HardwareType.CPU)
            // .Sensors.First(s => s.SensorType == SensorType.Temperature);
            // this.CpuTemperatureSensor =
            // this.MemoryUtilizationSensor =
            // this.Computer.Hardware.First(h => h.HardwareType == HardwareType.RAM)
            // .Sensors.First(s => s.SensorType == SensorType.Load && s.Name == "Memory");

            // this.MemoryUsedSensor =
            // this.Computer.Hardware.First(h => h.HardwareType == HardwareType.RAM)
            // .Sensors.First(s => s.SensorType == SensorType.Data && s.Name == "Used Memory");
            // this.MemoryAvailableSensor =
            // this.Computer.Hardware.First(h => h.HardwareType == HardwareType.RAM)
            // .Sensors.First(s => s.SensorType == SensorType.Data && s.Name == "Available Memory");
        }

        public float Value => this.GetValue();

        public void Add(ISensor sensor)
        {
            if (this.Contains(sensor))
            {
                return;
            }
            else
            {
                // get the right hardware
                var hardware = sensor.Hardware;
                while (hardware.Parent != null) hardware = hardware.Parent;

                // get the sensor list associated with the hardware
                IList<ISensor> list;
                if (!this.sensors.TryGetValue(hardware, out list))
                {
                    list = new List<ISensor>();
                    this.sensors.Add(hardware, list);
                }

                // insert the sensor at the right position
                var i = 0;
                while (i < list.Count
                       && (list[i].SensorType < sensor.SensorType
                           || (list[i].SensorType == sensor.SensorType && list[i].Index < sensor.Index))) i++;
                list.Insert(i, sensor);
            }
        }

        public bool Contains(ISensor sensor)
        {
            return this.sensors.Values.Any(list => list.Contains(sensor));
        }

        private float GetValue()
        {
            this.computer.Accept(this.visitor);
            return this.sensor.Value ?? 0;
        }

        private void HardwareAdded(IHardware hardware)
        {
            // Console.WriteLine("hwAdded");
            foreach (var hardwareSensor in hardware.Sensors)
            {
                this.SensorAdded(hardwareSensor);
            }

            hardware.SensorAdded += this.SensorAdded;
            hardware.SensorRemoved += this.SensorRemoved;
            foreach (var subHardware in hardware.SubHardware)
            {
                this.HardwareAdded(subHardware);
            }
        }

        private void Remove(ISensor sensor)
        {
            foreach (var keyValue in this.sensors)
                if (keyValue.Value.Contains(sensor))
                {
                    keyValue.Value.Remove(sensor);
                    if (!keyValue.Value.Any())
                    {
                        this.sensors.Remove(keyValue.Key);
                        break;
                    }
                }
        }

        private void SensorAdded(ISensor sensor)
        {
            this.Add(sensor);
        }

        private void SensorRemoved(ISensor sensor)
        {
            if (this.Contains(sensor)) this.Remove(sensor);
        }
    }
}