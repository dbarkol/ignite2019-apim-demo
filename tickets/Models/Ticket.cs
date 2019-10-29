using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace Tickets.Models
{
    public class Ticket
    {
        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("impact")]
        public string Impact { get; set; }

        [JsonProperty("productLine")]
        public string ProductLine { get; set; }

        #endregion

    }
}