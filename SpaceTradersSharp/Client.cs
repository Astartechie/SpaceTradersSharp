using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using ErrorOr;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SpaceTradersSharp;

internal class Client(ILogger<Client> logger, IHttpClientFactory httpClientFactory, IOptions<Settings> settings) : IClient
{
    public async Task<ErrorOr<TResponse>> GetAsync<TResponse>(string uri, CancellationToken cancellationToken = default)
    {
        try
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri)
            {
                Headers = { { "Authorization", $"Bearer {settings.Value.Token}" } }
            };

            var httpClient = httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken);

            if (!httpResponseMessage.IsSuccessStatusCode) return StatusCodeToError(httpResponseMessage.StatusCode);

            return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>(JsonSerializerOptions.Web, cancellationToken);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);
            return Error.Unexpected();
        }
    }

    private static Error StatusCodeToError(HttpStatusCode statusCode)
        => statusCode switch
        {
            HttpStatusCode.BadRequest => Error.Validation(),
            HttpStatusCode.Forbidden => Error.Forbidden(),
            HttpStatusCode.NotFound => Error.NotFound(),
            HttpStatusCode.Conflict => Error.Conflict(),
            HttpStatusCode.Unauthorized => Error.Unauthorized(),
            _ => Error.Failure()
        };
}