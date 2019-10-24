using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace Location.Api.Models
{
    public class Location
    {
        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        #endregion

        #region Helper Methods

        public static List<Location> GetAllLocations()
        {
            List<Location> locations = new List<Location>
            {
                new Models.Location
                {
                    Address = "5 Wayside Road",
                    Id = 1,
                    City = "Burlington",
                    Latitude = "42.48421",
                    Longitude = "-71.19155",
                    PostalCode = "01803",
                    State = "MA"
                },
                new Models.Location
                {
                    Address = "700 Bellevue Way NE, Floor 22",
                    Id = 2,
                    City = "Bellevue",
                    Latitude = "47.623384",
                    Longitude = "-122.220297",
                    PostalCode = "98004",
                    State = "WA"
                },
                new Models.Location
                {
                    Address = "11 Times Square, 7th Floor",
                    Id = 3,
                    City = "New York",
                    Latitude = "40.75662",
                    Longitude = "-73.98979",
                    PostalCode = "10036",
                    State = "NY"
                },
                new Models.Location
                {
                    Address = "7595 Technology Way, Suite 400",
                    Id = 4,
                    City = "Denver",
                    Latitude = "39.632105",
                    Longitude = "-104.908316",
                    PostalCode = "80237",
                    State = "CO"
                }
            };

            return locations;
        }

        public static Location GetLocationById(int locationId)
        {
            List<Location> locations = GetAllLocations();
            var l = locations.Where(x => x.Id == locationId).ToList();
            return l.FirstOrDefault();
        }

        #endregion
    }
}
