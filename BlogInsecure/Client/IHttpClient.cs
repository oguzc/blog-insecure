using System.Net.Http;
using System.Threading.Tasks;

namespace BlogInsecure.Client
{
    public interface IHttpClient
    {
        HttpRequestMessage CreateGetRequest(string uri);
        HttpRequestMessage CreatePostRequest<T>(string uri, T item);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
    }
}
