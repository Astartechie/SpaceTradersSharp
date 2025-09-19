using ErrorOr;

namespace SpaceTradersSharp;

internal interface IClient
{
    Task<ErrorOr<TResponse>> GetAsync<TResponse>(string uri, CancellationToken cancellationToken = default);
}