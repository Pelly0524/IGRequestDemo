using Microsoft.VisualStudio.TestTools.UnitTesting;
using IGRequestDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IGRequestDemo.Models.Requests;

namespace IGRequestDemo.Tests
{
    [TestClass()]
    public class IGTradeTests
    {
        private readonly string account = "account";
        private readonly string password = "password";

        [TestMethod()]
        public async Task LoginTest()
        {
            var restApiClient = new RestApiClient();
            var loginResponse = await restApiClient.Login(account, password);
        }

        [TestMethod()]
        public async Task CreateOrderTest()
        {
            var restApiClient = new RestApiClient();
            var loginResponse = await restApiClient.Login(account, password);

            var request = new CreateWorkingOrderRequest
            {
                currencyCode = "USD",
                dealReference = null,
                direction = Direction.BUY,
                epic = "IX.D.SUNNAS.BMU.IP",
                expiry = "-",
                goodTillDate = null,
                guaranteedStop = false,
                level = 14700.7m,
                limitDistance = null,
                limitLevel = 14750.7m,
                size = 1.0m,
                stopDistance = null,
                stopLevel = 14650.7m,
                timeInForce = TimeInForce.GOOD_TILL_CANCELLED,
                type = WorkingOrderType.LIMIT
            };

            var response = await restApiClient.CreateOrder(request);
        }

        [TestMethod()]
        public async Task GetWatchListTest()
        {
            var restApiClient = new RestApiClient();
            var loginResponse = await restApiClient.Login(account, password);

            var watchlistResponse = await restApiClient.GetWatchList();
        }

        [TestMethod()]
        public async Task SocketConnectTest()
        {
            var restApiClient = new RestApiClient();
            var loginResponse = await restApiClient.Login(account, password);

            StreamingApiClient streamingApiClient = new StreamingApiClient(loginResponse.LightstreamerEndpoint);
            await streamingApiClient.Connect(account, loginResponse.cst, loginResponse.xSecurityToken);

            streamingApiClient.Disconnect();
        }

        [TestMethod()]
        public async Task SubscribeMarketTest()
        {
            var restApiClient = new RestApiClient();
            var loginResponse = await restApiClient.Login(account, password);

            StreamingApiClient streamingApiClient = new StreamingApiClient(loginResponse.LightstreamerEndpoint);
            await streamingApiClient.Connect(account, loginResponse.cst, loginResponse.xSecurityToken);

            var epics = new List<string>() { "IX.D.SUNNAS.BMU.IP" };
            streamingApiClient.SubscribeMarket(epics);

            streamingApiClient.Disconnect();
        }
    }
}