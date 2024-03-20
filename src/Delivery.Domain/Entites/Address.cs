namespace Delivery.Domain.Entites;

public sealed record Address : EntityBase<Address>
{
    public string Type { get; init; }
    public Point Coordinates { get; init; }

    public Address(int id, string type, Point coordinates) : base(id)
    {
        Type = type;
        Coordinates = coordinates;
    }
}
