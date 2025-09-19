using ErrorOr;
using MediateSharp;

namespace SpaceTradersSharp.Agents;

public record GetAllAgentsQuery(int Page = 1) : IRequest<ErrorOr<PagedResponse<Agent>>>;

