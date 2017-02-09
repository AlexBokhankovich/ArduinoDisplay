namespace ArduinoDisplay.WeatherPlugin
{
    using System;
    using System.Threading;

    using ArduinoDisplay.PluginInterface;
    using ArduinoDisplay.WeatherPlugin.Providers;

    /// <summary>
    ///     The weather.
    /// </summary>
    public class WeatherPlugin : IArduinoDisplayPlugin
    {
        /// <summary>
        ///     The data ready.
        /// </summary>
        public event EventHandler<DataReadyEventArgs> DataReady;

        /// <summary>
        /// The api key.
        /// </summary>
        public string ApiKey => this.GetApiKey();

        /// <summary>
        /// The city.
        /// </summary>
        public string City => this.GetCity();

        /// <summary>
        /// The country code.
        /// </summary>
        public string CountryCode => this.GetCountryCode();

        /// <summary>
        ///     The name.
        /// </summary>
        public string Name => "Weather";

        /// <summary>
        /// Gets or sets the timer.
        /// </summary>
        public Timer Timer { get; set; }

        /// <summary>
        /// The update interval.
        /// </summary>
        public int UpdateInterval => this.GetUpdateInterval();

        /// <summary>
        /// Gets or sets the updater.
        /// </summary>
        public IUpdater<WeatherUpdateEventArgs, string> Updater { get; set; }

        /// <summary>
        /// The weather provider type.
        /// </summary>
        public WeatherProviderType WeatherProviderType => this.GetWeatherProviderType();

        /// <summary>
        /// Gets or sets the config.
        /// </summary>
        private WeatherConfig Config { get; set; }

        /// <summary>
        /// Gets or sets the forecast provider.
        /// </summary>
        private ForecastProvider ForecastProvider { get; set; }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public void Configure(dynamic config)
        {
            this.Config = new WeatherConfig
                              {
                                  City = config.City,
                                  CountryCode = config.CountryCode,
                                  Provider = config.Provider,
                                  UpdateInterval = config.UpdateInterval ?? 1000 * 60 * 60,
                                  ApiKey = config.ApiKey
                              };
        }

        /// <summary>
        ///     The init.
        /// </summary>
        public void Init()
        {
            switch (this.WeatherProviderType)
            {
                case WeatherProviderType.OpenWeatherMap:
                    var weatherProv = new OpenWeatherMapProvider(this.ApiKey);

                    this.ForecastProvider = new ForecastProvider(
                        weatherProv,
                        cityName: this.City,
                        countryCode: this.CountryCode);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///     The start.
        /// </summary>
        public void Start()
        {
            this.Updater = new WeatherUpdater(this.ForecastProvider, this.UpdateInterval);
            this.Updater.DataReady += this.UpdaterDataReady;
            this.Updater.Start();
        }

        /// <summary>
        /// The get api key.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetApiKey()
        {
            return this.Config.ApiKey;
        }

        /// <summary>
        /// The get city.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetCity()
        {
            return this.Config.City;
        }

        /// <summary>
        /// The get country code.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetCountryCode()
        {
            return this.Config.CountryCode;
        }

        /// <summary>
        /// The get update interval.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetUpdateInterval()
        {
            return this.Config.UpdateInterval;
        }

        /// <summary>
        /// The get weather provider type.
        /// </summary>
        /// <returns>
        /// The <see cref="WeatherProviderType"/>.
        /// </returns>
        private WeatherProviderType GetWeatherProviderType()
        {
            switch (this.Config.Provider.ToLowerInvariant())
            {
                case "openweathermap":
                    return WeatherProviderType.OpenWeatherMap;
                default:
                    return WeatherProviderType.OpenWeatherMap;
            }
        }

        /// <summary>
        /// The updater_ data ready.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UpdaterDataReady(object sender, WeatherUpdateEventArgs e)
        {
            this.DataReady?.Invoke(this, new DataReadyEventArgs(e.Weather));
        }
    }
}