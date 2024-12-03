namespace Spotify.SPG
{
    public class HttpClientHandler : IHttpClientHandler
    {

        private readonly HttpClient _client;

        public HttpClientHandler(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint, HttpMethod method, HttpRequestMessage content)
        {
            var requestUri = new Uri(_client.BaseAddress!, endpoint);

            return await _client.SendAsync(content);
        }
        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }
    }
}
