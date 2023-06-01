using Newtonsoft.Json;
using NQR.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Common.Shared.HttpService
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _clientFactory;


        public HttpService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> SendPostRequest<T, U>(PostRequest<U> request)
        {
            var client = _clientFactory.CreateClient();
            var message = new HttpRequestMessage();
            message.RequestUri = new Uri(request.Url);
            message.Method = HttpMethod.Post;
           // message.Headers.Add("Accept", "application/json 
            message.Headers.Add("Accept", "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.Clear();
            message.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                    ["grant_type"] = request.grand_type,
                    ["client_id"] = request.client_id,
                    ["client_secret"] = request.client_secret,
                    ["scope"] = request.scope
            });
            var response = await client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
           // _logger.LogInformation("Response from {Url} is {response}", message.RequestUri, content);
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<T> SendAuthPostRequest<T, U>(AuthPostRequest<U> request)
        {
            var client = _clientFactory.CreateClient();
            var message = new HttpRequestMessage();
            message.RequestUri = new Uri(request.Url);
            message.Method = HttpMethod.Post;
            message.Headers.Add("Accept", "application/json");
            //message.Headers.Add("Authorization", request.authorization);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.authorization);
            // client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Add("Authorization","Bearer" + request.authorization);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.authorization ?? "");
            //*//*client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);*/
            var data = JsonConvert.SerializeObject(request.Data);
            message.Content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }


        public async Task<T> SendAuthGetRequest<T,U>(GetRequest<U> request)
        {
            var client = _clientFactory.CreateClient();
            var message = new HttpRequestMessage();
            message.RequestUri = new Uri(request.Url);
            message.Method = HttpMethod.Get;
            message.Headers.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.Authorization ?? "");
            client.DefaultRequestHeaders.Clear();
            // _logger.LogInformation("Sending GET request to {Url}", message.RequestUri);
            var data = JsonConvert.SerializeObject(request.Data);
            // _logger.LogInformation("Sending POST request to {Url} with Body {data}", message.RequestUri, data);
            message.Content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
           // _logger.LogInformation("Response from {Url} is {response}", message.RequestUri, content);
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
