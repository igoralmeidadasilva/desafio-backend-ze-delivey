namespace Delivery.Application.Querys.GetPartnerById;

public record GetPartnerByIdRequest : IRequest<Result<PartnerDto>>
{
    public int Id { get; set; }

    // public GetPartnerByIdRequest(int id)
    // {
    //     Id = id;
    // }
}
