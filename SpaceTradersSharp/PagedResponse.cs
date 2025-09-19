namespace SpaceTradersSharp;

public record PagedResponse<TData> : Response<TData[]>
{
    public required Paging Meta { get; init; }
}