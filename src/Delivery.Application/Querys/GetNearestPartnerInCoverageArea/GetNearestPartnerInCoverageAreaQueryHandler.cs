namespace Delivery.Application.Querys.GetNearestPartnerInCoverageArea;

public sealed class GetNearestPartnerInCoverageAreaQueryHandler : IRequestHandler<GetNearestPartnerInCoverageAreaQuery, Result<PartnerDto>>
{
    private readonly ILogger<GetNearestPartnerInCoverageAreaQueryHandler> _logger;
    private readonly IPartnerRepository _repo;
    private IMapper _mapper;
    public GetNearestPartnerInCoverageAreaQueryHandler(ILogger<GetNearestPartnerInCoverageAreaQueryHandler> logger, IPartnerRepository repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Result<PartnerDto>> Handle(GetNearestPartnerInCoverageAreaQuery request, CancellationToken cancellationToken)
    {
        Point location = new(request.Longitude, request.Latitude);
        IEnumerable<Partner> partners = await _repo.GetPartners();
        Partner nearestPartner = await FetchNearestPartnersInCoverageArea(partners, location);

        if(nearestPartner is null)
        {
            return Result<PartnerDto>.Failure(PartnerErrors.NearestPartnerNotFound());
        }

        var mappedResult = _mapper.Map<PartnerDto>(nearestPartner);
        return Result<PartnerDto>.Success(mappedResult);
    }

    private async ValueTask<Partner> FetchNearestPartnersInCoverageArea(IEnumerable<Partner> partners, Point targetLocation)
    {
        Partner nearestPartner = null!;
        double shortDistance = double.MaxValue;
        foreach(Partner partner in partners)
        {
            if(partner.CoverageArea!.Coordinates.Contains(targetLocation))
            {
                double distance = targetLocation.Distance(partner.Address!.Coordinates);

                if(distance < shortDistance)
                {
                    shortDistance = distance;
                    nearestPartner = partner;
                }
            }
        }
        return await Task.FromResult(nearestPartner);
    }
}