using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGRequestDemo.Models.Responses
{
    public class WatchlistResponse
    {
        public List<WatchlistItem> watchlists { get; set; } = new List<WatchlistItem>();
    }

    public class WatchlistItem
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("editable")]
        public bool Editable { get; set; }

        [JsonProperty("deleteable")]
        public bool Deleteable { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("defaultSystemWatchlist")]
        public bool DefaultSystemWatchlist { get; set; }
    }
}
