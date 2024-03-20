namespace Delivery.Application.Querys.GetNearestPartnerInCoverageArea;

public sealed record GetNearestPartnerInCoverageAreaQuery : IRequest<Result<PartnerDto>>
{
    public int Id { get; set; }
}
