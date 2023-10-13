using com.lightstreamer.client;
using IGRequestDemo.Helpers;
using IGRequestDemo.Models.Requests;
using IGRequestDemo.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace IGRequestDemo
{
    public class RestApiClient
    {
        private readonly HttpHelper _httpHelper = new HttpHelper();
        private readonly string _baseUrl = "https://demo-api.ig.com/gateway/deal";

        public RestApiClient()
        {
            _httpHelper.AddRequestHeader("X-IG-API-KEY", "4f2b6ed0c50e0b7bd685f1e275fa318f94a333de");
            _httpHelper.AddRequestHeader("VERSION", "1");
        }

        public async Task<LoginResponse> Login(string identifier, string password)
        {
            var url = $"{_baseUrl}/session";

            // Post Body
            var bodyContent = new { identifier, password };
            var jsonContent = JsonConvert.SerializeObject(bodyContent);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // 發出request
            var response = await _httpHelper.PostAsyncWithResponse(url, content);
            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(await response.Content.ReadAsStringAsync()) ?? throw new InvalidOperationException("The response content is null or empty.");

            // 登入token處理
            string cst = response.Headers.GetValues("CST").FirstOrDefault() ?? throw new InvalidOperationException("CST header is missing in the response."); ;
            string xSecurityToken = response.Headers.GetValues("X-SECURITY-TOKEN").FirstOrDefault() ?? throw new InvalidOperationException("X-SECURITY-TOKEN header is missing in the response."); ;

            _httpHelper.AddRequestHeader("CST", cst);
            _httpHelper.AddRequestHeader("X-SECURITY-TOKEN", xSecurityToken);

            loginResponse.cst = cst;
            loginResponse.xSecurityToken = xSecurityToken;

            return loginResponse;
        }

        public async Task<WatchlistResponse> GetWatchList()
        {
            var url = $"{_baseUrl}/watchlists";
            var jsonResponse = await _httpHelper.GetAsync(url);
            var response = JsonConvert.DeserializeObject<WatchlistResponse>(jsonResponse) ?? throw new InvalidOperationException("Failed to deserialize the watchlist response.");

            return response;
        }

        public async Task<string> CreateOrder(CreateWorkingOrderRequest createWorkingOrderRequest)
        {
            var url = $"{_baseUrl}/workingorders/otc";

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter());

            var jsonContent = JsonConvert.SerializeObject(createWorkingOrderRequest, settings);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            return await _httpHelper.PostAsync(url, content);
        }

    }

}
