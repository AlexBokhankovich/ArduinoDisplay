namespace ArduinoDisplay.Core
{
    using System;
    using System.IO;

    using ArduinoDisplay.Configuration;

    using Newtonsoft.Json;

    /// <summary>
    /// The config manager.
    /// </summary>
    public class ConfigManager
    {
        readonly string fileName = "settings.json";

        /// <summary>
        /// Gets or sets the config.
        /// </summary>
        public Configuration Config { get; set; }

        /// <summary>
        /// The load.
        /// </summary>
        /// <returns>
        /// The <see cref="ArduinoDisplayConfiguration"/>.
        /// </returns>
        public void Load()
        {
            var fileExists = File.Exists(this.fileName);
            if (fileExists)
            {
                using (var r = new StreamReader(this.fileName))
                {
                    var json = r.ReadToEnd();
                    this.Config = JsonConvert.DeserializeObject<Configuration>(json);
                }
            }
            else
            {
                this.GenerateBaseSettingsFile();
                this.Load();
            }
        }

        /// <summary>
        /// The generate base settings file.
        /// </summary>
        private void GenerateBaseSettingsFile()
        {
            // TODO CHANGE THIS
            var cfg = new Configuration();

            var json = JsonConvert.SerializeObject(cfg);

            // write string to file
            File.WriteAllText(this.fileName, json);
        }
    }
}