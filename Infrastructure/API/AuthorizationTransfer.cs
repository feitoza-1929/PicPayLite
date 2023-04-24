using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Options;
using PicPayLite.Infrastructure.Options;

namespace PicPayLite.Infrastructure.API
{
    public class AuthorizationTransfer : IAuthorizationTransfer
    {
        private readonly HttpClient httpClient;

        private readonly Uri _requestUri;

        public AuthorizationTransfer(IOptions<RequestURIOptions> requestURI)
        {
            _requestUri = new Uri(requestURI.Value.URI);
            httpClient = new() { BaseAddress = _requestUri };
        }

        public async Task<AuthTransfer> GetAsync()
        {
            return await httpClient.GetFromJsonAsync<AuthTransfer>("notify");
        }
    }

    public record AuthTransfer
    {
        public string Message { get; init; }
    }
}
