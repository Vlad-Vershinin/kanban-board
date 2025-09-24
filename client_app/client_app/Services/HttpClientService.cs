using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace client_app.Services;

public class HttpClientService : IHttpClientService
{
    public HttpClient _HttpClient { get; set; }

    public HttpClientService()
    {
        _HttpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:7084/api/")
        };
    }

    public async Task<HttpResponseMessage> PostAsJsonAsync<T>(string url, T obj)
    {
        return await _HttpClient.PostAsJsonAsync(url, obj);
    }

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        return await _HttpClient.GetAsync(url);
    }
}
