namespace Delivery.Application.Commands.CreatePartner;

public sealed record CreatePartnerCommand : IRequest<Result<int>>
{
    public string? TradingName { get; set; }
    public string? OwnerName { get; set; }
    public string? Document { get; set; }
    public MultiPolygon? CoverageArea { get; set; }
    public Point? Address { get; set; }
}



