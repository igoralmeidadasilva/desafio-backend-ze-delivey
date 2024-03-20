namespace Delivery.Application.Querys.GetPartnerById;

public sealed record GetPartnerByIdQuery : IRequest<Result<PartnerDto>>
{
    public int Id { get; set; }
}
