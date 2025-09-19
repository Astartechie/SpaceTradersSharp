namespace SpaceTradersSharp.Agents;

public record Agent
{
    public string Symbol { get; init; } = string.Empty;
    public string Headquarters { get; init; } = string.Empty;
    public int Credits { get; init; }
    public string StartingFaction { get; init; } = string.Empty;
    public int ShipCount { get; init; }
}