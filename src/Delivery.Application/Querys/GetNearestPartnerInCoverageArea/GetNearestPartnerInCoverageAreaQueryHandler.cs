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
        Partner targetPartner = await _repo.GetPartnerById(request.Id);
        IEnumerable<Partner> partners = await _repo.GetPartnersForComparisonInCoverageArea(request.Id);
        Partner nearestPartner = await FetchNearestPartnersInCoverageArea(partners, targetPartner);

        if(nearestPartner is null)
        {
            return Result<PartnerDto>.Failure(PartnerErrors.NearestPartnerNotFound(request.Id));
        }

        var mappedResult = _mapper.Map<PartnerDto>(nearestPartner);
        return Result<PartnerDto>.Success(mappedResult);
    }

    private async ValueTask<Partner> FetchNearestPartnersInCoverageArea(IEnumerable<Partner> partners, Partner targetPartner)
    {
        Partner nearestPartner = null!;
        double shortDistance = double.MaxValue;
        foreach(Partner partner in partners)
        {
            if(targetPartner.CoverageArea!.Coordinates.Contains(partner.Address!.Coordinates))
            {
                double distance = targetPartner.Address!.Coordinates.Distance(partner.Address.Coordinates);

                // TODO: Debugar esse if
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