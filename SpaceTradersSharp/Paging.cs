namespace SpaceTradersSharp;

public record Paging
{
    public int Total { get; init; }
    public int Page { get; init; }
    public int Limit { get; init; }
}