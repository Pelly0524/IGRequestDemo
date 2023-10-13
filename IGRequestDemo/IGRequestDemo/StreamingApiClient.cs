using com.lightstreamer.client;
using IGRequestDemo.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGRequestDemo
{
    public class StreamingApiClient
    {
        private LightstreamerClient _lightstreamerClient;

        public StreamingApiClient(string lightstreamerEndpoint)
        {
            _lightstreamerClient = new LightstreamerClient(lightstreamerEndpoint, null);
        }

        public async Task Connect(string activeAccountId, string client_token, string account_token)
        {
            var connectListener = new ConnectListener();

            _lightstreamerClient.addListener(connectListener);
            _lightstreamerClient.connectionDetails.User = activeAccountId;
            _lightstreamerClient.connectionDetails.Password = "CST-" + client_token + "|XST-" + account_token;
            _lightstreamerClient.connect();

            await connectListener.ConnectionTask;
        }

        public void SubscribeMarket(List<string> epics)
        {
            var items = epics.Select(e => $"MARKET:{e}").ToArray();

            var fields = new[] {
                "MID_OPEN", "HIGH", "LOW", "CHANGE", "CHANGE_PCT", "UPDATE_TIME",
                "MARKET_DELAY", "MARKET_STATE", "BID", "OFFER"
            };

            // 建立 Subscription 物件
            Subscription subscription = new Subscription("MERGE", items, fields);
            subscription.addListener(new MarketListener());

            // 進行訂閱
            _lightstreamerClient.subscribe(subscription);
        }

        public void Disconnect()
        {
            _lightstreamerClient.disconnect();
        }
    }

}
