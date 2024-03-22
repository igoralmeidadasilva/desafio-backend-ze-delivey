namespace Delivery.Domain.Entites;

public sealed record CoverageArea : EntityBase<CoverageArea>
{
    public string Type { get; init; }
    public MultiPolygon Coordinates { get; init; }
    public CoverageArea(int id, string type, MultiPolygon coordinates) : base(id)
    {
        Type = type;
        Coordinates = coordinates;
    }

    public CoverageArea(string type, MultiPolygon coordinates)
    {
        Type = type;
        Coordinates = coordinates;
    }
}
