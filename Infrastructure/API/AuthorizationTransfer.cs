using System.Text.Json;
using Microsoft.Extensions.Options;
using PicPayLite.Infrastructure.Options;

namespace PicPayLite.Infrastructure.API
{
    public class AuthorizationTransfer : IAuthorizationTransfer
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _requestUri;

        public AuthorizationTransfer(IHttpClientFactory httpClientFactory, IOptions<RequestURIOptions> requestURI)
        {
            _httpClientFactory = httpClientFactory;
            _requestUri = requestURI.Value.URIs["AuthTransfer"];
        }

        public async Task<AuthData> GetAsync()
        {
            HttpRequestMessage httpRequestMessage = new(
                HttpMethod.Get,
                _requestUri
            );

            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if(httpResponseMessage.IsSuccessStatusCode is false)
                return new AuthData();

            var streamData = await httpResponseMessage.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<AuthData>(streamData);

            if(data is null)
                return new AuthData();
                
            return data;
        }
    }

    public class AuthData
    {
        public string Message { get; set; }
    }
}