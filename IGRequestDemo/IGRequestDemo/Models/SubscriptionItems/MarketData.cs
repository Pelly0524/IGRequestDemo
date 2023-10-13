using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGRequestDemo.Models.SubscriptionItems
{
    public class MarketData
    {
        [JsonProperty("Mid_Open")]
        public double MidOpen { get; set; }

        [JsonProperty("High")]
        public double High { get; set; }

        [JsonProperty("Low")]
        public double Low { get; set; }

        [JsonProperty("Change")]
        public double Change { get; set; }

        [JsonProperty("Change_Pct")]
        public double ChangePct { get; set; }

        [JsonProperty("Update_Time")]
        public string UpdateTime { get; set; } = string.Empty;

        [JsonProperty("Market_Delay")]
        public int MarketDelay { get; set; }

        [JsonProperty("Market_State")]
        public string MarketState { get; set; } = string.Empty;

        [JsonProperty("Bid")]
        public double Bid { get; set; }

        [JsonProperty("Offer")]
        public double Offer { get; set; }

        [JsonProperty("Epic")]
        public string Epic { get; set; } = string.Empty;

        public void PrintProperties()
        {
            Console.WriteLine($"MidOpen: {MidOpen}, High: {High}, Low: {Low}, " +
                $"Change: {Change}, ChangePct: {ChangePct}, " +
                $"UpdateTime: {UpdateTime}, MarketDelay: {MarketDelay}, " +
                $"MarketState: {MarketState}, Bid: {Bid}, " +
                $"Offer: {Offer}, Epic: {Epic}"
            );
        }
    }
}
