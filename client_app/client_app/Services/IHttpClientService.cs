using System.Net.Http;
using System.Threading.Tasks;

namespace client_app.Services;

public interface IHttpClientService
{
    HttpClient _HttpClient { get; set; }

    Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T obj);
    Task<HttpResponseMessage> GetAsync(string url);
}
