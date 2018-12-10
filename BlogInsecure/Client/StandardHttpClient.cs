using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlogInsecure.Client
{
    public class StandardHttpClient : IHttpClient
    {
        private static readonly HttpClient Client = new HttpClient();

        public HttpRequestMessage CreateGetRequest(string uri)
        {
            return new HttpRequestMessage(HttpMethod.Get, uri);
        }

        public HttpRequestMessage CreatePostRequest<T>(string uri, T item)
        {
            return new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json"),
            };
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
        {
            var response = await Client.SendAsync(httpRequestMessage);

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }

            return response;
        }
    }
}