using com.lightstreamer.client;
using IGRequestDemo.Models.SubscriptionItems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGRequestDemo.Listeners
{
    public class MarketListener : SubscriptionListener
    {
        public void onClearSnapshot(string itemName, int itemPos)
        {
            Console.WriteLine($"ClearSnapshot for item {itemName} at position {itemPos}");
        }

        public void onCommandSecondLevelItemLostUpdates(int lostUpdates, string key)
        {
            Console.WriteLine($"Lost updates: {lostUpdates} for key: {key}");
        }

        public void onCommandSecondLevelSubscriptionError(int code, string message, string key)
        {
            Console.WriteLine($"Subscription error for key {key}. Code: {code}, Message: {message}");
        }

        public void onEndOfSnapshot(string itemName, int itemPos)
        {
            Console.WriteLine($"End of snapshot for item {itemName} at position {itemPos}");
        }

        public void onItemLostUpdates(string itemName, int itemPos, int lostUpdates)
        {
            Console.WriteLine($"Item {itemName} at position {itemPos} lost {lostUpdates} updates");
        }

        public void onItemUpdate(ItemUpdate itemUpdate)
        {
            if (itemUpdate == null || itemUpdate.Fields == null)
                throw new ArgumentNullException(nameof(itemUpdate));

            var json = JsonConvert.SerializeObject(itemUpdate.Fields, Formatting.Indented);
            var marketData = JsonConvert.DeserializeObject<MarketData>(json) ?? throw new InvalidOperationException("MarketData Deserialize Fail");
            marketData.Epic = itemUpdate.ItemName.Replace("MARKET:", string.Empty);
            marketData.PrintProperties();
        }

        public void onListenEnd(Subscription subscription)
        {
            Console.WriteLine($"Listening ended for MarketSubscription");
        }

        public void onListenStart(Subscription subscription)
        {
            Console.WriteLine($"Listening started for MarketSubscription");
        }

        public void onSubscription()
        {
            Console.WriteLine("Subscription started");
        }

        public void onSubscriptionError(int code, string message)
        {
            Console.WriteLine($"Subscription Error: Code = {code}, Message = {message}");
        }

        public void onUnsubscription()
        {
            Console.WriteLine("Unsubscribed from items");
        }

        public void onRealMaxFrequency(string frequency)
        {
            Console.WriteLine($"Real max frequency set to: {frequency}");
        }
    }


}
