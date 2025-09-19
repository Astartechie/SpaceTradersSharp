using ErrorOr;
using MediateSharp;

namespace SpaceTradersSharp.Agents;

internal class GetAllAgentsQueryHandler(IClient client) : IRequestHandler<GetAllAgentsQuery, ErrorOr<PagedResponse<Agent>>>
{
    private const string Endpoint = "https://api.spacetraders.io/v2/agents";

    public Task<ErrorOr<PagedResponse<Agent>>> HandleAsync(GetAllAgentsQuery request, CancellationToken cancellationToken = default)
        => client.GetAsync<PagedResponse<Agent>>($"{Endpoint}?page={request.Page}", cancellationToken);
}