namespace Delivery.Domain.Entites;

public record Partner : EntityBase<Partner>
{
    public string TradingName { get; init; }
    public string OwnerName { get; init; }
    public string Document { get; init; }
    public int CoverageAreaId { get; init; }
    public int AddressId { get; init; }
    public virtual CoverageArea? CoverageArea { get; init; }
    public virtual Address? Address { get; init; }

    public Partner(int id,
                   string tradingName,
                   string ownerName,
                   string document,
                   int coverageAreaId,
                   int addressId) : base(id)
    {
        TradingName = tradingName;
        OwnerName = ownerName;
        Document = document;
        CoverageAreaId = coverageAreaId;
        AddressId = addressId;
    }
}
