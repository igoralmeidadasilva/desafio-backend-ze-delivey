using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Delivery.Domain.Entites;

public sealed record Address : EntityBase<Address>
{
    public string Type { get; private set; }
    public Point Coordinates { get; private set; }
    public Address(int id, string type, Point coordinates) : base(id)
    {
        Type = type;
        Coordinates = coordinates;
    }
}
