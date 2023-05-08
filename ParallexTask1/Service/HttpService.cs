using Newtonsoft.Json;
using ParallexTask1.Dto;
using ParallexTask1.Interface;
using System.Net.Http.Headers;
using System.Text;

namespace ParallexTask1.Service
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _clientFactory;
        public HttpService(IHttpClientFactory  clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> SendPostRequest<T, U>(PostRequest<U> request)
        {
            var client = _clientFactory.CreateClient();
            var message = new HttpRequestMessage();
            message.RequestUri = new Uri(request.Url);
            message.Method = HttpMethod.Post;
            message.Headers.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Add("X-CID", clientSecretKey);
            var data = JsonConvert.SerializeObject(request.Data);
            message.Content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<T> SendAuthPostRequest<T, U>(PostRequest2<U> request)
        {  
            var client = _clientFactory.CreateClient();
            var message = new HttpRequestMessage();
            message.RequestUri = new Uri(request.Url);
            message.Method = HttpMethod.Post;
            message.Headers.Add("Accept", "application/json");
            //message.Headers.Add("Authorization", request.authorization);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.authorization);
            // client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Add("Authorization","Bearer" + request.authorization);
            /*client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.authorization ?? "");
            *//*client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);*/
            var data = JsonConvert.SerializeObject(request.Data);
            message.Content = new StringContent(data, Encoding.UTF8, "application/json"); 
            var response = await client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

    }
}
