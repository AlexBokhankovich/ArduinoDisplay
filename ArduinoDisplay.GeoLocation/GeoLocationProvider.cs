namespace ArduinoDisplay.GeoLocation
{
    using System.Net.Http;

    using ArduinoDisplay.GeoCommon;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The geo location provider.
    /// </summary>
    public class GeoLocationProvider : IGeoLocationProvider
    {
        /// <summary>
        /// The client.
        /// </summary>
        private HttpClient client;

        /// <summary>
        /// Gets the city.
        /// </summary>
        public string City => this.GetCity();

        /// <summary>
        /// Gets the client.
        /// </summary>
        public HttpClient Client => this.client ?? (this.client = new HttpClient());

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        public Coordinate Coordinate => this.GetLongitudeLattitude();

        /// <summary>
        /// Gets the country code.
        /// </summary>
        public string CountryCode
        {
            get
            {
                var rawInfo = this.GetRawInfo();
                return rawInfo.country_code.ToString();
            }
        }

        /// <summary>
        /// The get city.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetCity()
        {
            return this.GetRawInfo().city.ToString();
        }

        /// <summary>
        /// The get longitude lattitude.
        /// </summary>
        /// <returns>
        /// The <see cref="Coordinate"/>.
        /// </returns>
        private Coordinate GetLongitudeLattitude()
        {
            var location = this.GetRawInfo();

            return new Coordinate { Latitude = location.latitude, Longitude = location.longitude };
        }

        /// <summary>
        /// The get raw info.
        /// </summary>
        /// <returns>
        /// The <see cref="dynamic"/>.
        /// </returns>
        private dynamic GetRawInfo()
        {
            var responseJson = this.Client.GetStringAsync("http://freegeoip.net/json/").Result;

            return JObject.Parse(responseJson);
        }
    }
}