namespace Delivery.Application.Querys.GetNearestPartnerInCoverageArea;

public sealed record GetNearestPartnerInCoverageAreaQuery : IRequest<Result<PartnerDto>>
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}
