namespace SpaceTradersSharp;

public record Response<TData>
{
    public required TData Data { get; init; }
}