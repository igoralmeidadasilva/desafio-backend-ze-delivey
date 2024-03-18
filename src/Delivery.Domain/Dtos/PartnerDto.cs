namespace Delivery.Domain.Dtos;

public record PartnerDto
{
    public int Id { get; init; }
    public string? TradingName { get; init; }
    public string? OwnerName { get; init; }
    public string? Document { get; init; }
    public CoverageAreaDto CoverageArea { get; set; }
    public AddressDto Address { get; set; }
}
