using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IGRequestDemo.Helpers
{
    public class HttpHelper
    {
        private HttpClient _httpClient;

        public HttpHelper()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void AddRequestHeader(string headerName, string headerValue)
        {
            if (_httpClient.DefaultRequestHeaders.Contains(headerName))
            {
                _httpClient.DefaultRequestHeaders.Remove(headerName);
            }
            _httpClient.DefaultRequestHeaders.Add(headerName, headerValue);
        }

        public async Task<HttpResponseMessage> GetAsyncWithResponse(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await GetAsyncWithResponse(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> PostAsyncWithResponse(string url, HttpContent content)
        {
            var response = await _httpClient.PostAsync(url, content);
            //response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<string> PostAsync(string url, HttpContent content)
        {
            var response = await PostAsyncWithResponse(url, content);
            return await response.Content.ReadAsStringAsync();
        }

    }
}
