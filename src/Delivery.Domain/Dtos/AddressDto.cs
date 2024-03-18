using NetTopologySuite.Geometries;

namespace Delivery.Domain.Dtos;

public readonly record struct AddressDto
{
    public string Type { get; init; }
    public string Coordinates { get; init; }
}
