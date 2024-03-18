using NetTopologySuite.Geometries;

namespace Delivery.Domain.Entites;

public sealed record CoverageArea : EntityBase<CoverageArea>
{
    public string Type { get; private set; }
    public MultiPolygon Coordinates { get; private set; }
    
    public CoverageArea(int id, string type, MultiPolygon coordinates) : base(id)
    {
        Type = type;
        Coordinates = coordinates;
    }
}
