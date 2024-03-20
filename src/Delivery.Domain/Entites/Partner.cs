namespace Delivery.Domain.Entites;

public sealed record Partner : EntityBase<Partner>
{
    public string TradingName { get; private set; }
    public string OwnerName { get; private set; }
    public string Document { get; private set; }
    public int CoverageAreaId { get; set; }
    public CoverageArea? CoverageArea { get; set; }
    public int AddressId { get; set; }
    public Address? Address { get; set; }

    public Partner(int id, string tradingName, string ownerName, string document, int coverageAreaId, int addressId) : base(id)
    {
        TradingName = tradingName;
        OwnerName = ownerName;
        Document = document;
        CoverageAreaId = coverageAreaId;
        AddressId = addressId;
    }
}
