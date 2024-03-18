namespace Delivery.Application.Querys.GetPartnerById;

public sealed class GetPartnerByIdRequestHandler : IRequestHandler<GetPartnerByIdRequest, Result<PartnerDto>>
{
    private readonly ILogger<GetPartnerByIdRequestHandler> _logger;
    private readonly IPartnerRepository _repo;
    private IMapper _mapper;

    public GetPartnerByIdRequestHandler(ILogger<GetPartnerByIdRequestHandler> logger, IPartnerRepository repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Result<PartnerDto>> Handle(GetPartnerByIdRequest request, CancellationToken cancellationToken)
    {
        var partner = await _repo.GetPartnerById(request.Id);

        if(partner is null)
        {
            _logger.LogError("Error in fetching partner with id {PartnerId} em handler {className}", request.Id, nameof(GetPartnerByIdRequestHandler));
            return Result<PartnerDto>.Failure(PartnerErrors.PartnerNotFound(request.Id));
        }

        var result = _mapper.Map<PartnerDto>(partner);

        var address = await _repo.GetAddressById(partner.AddressId);
        var addressDto = _mapper.Map<AddressDto>(address);

        var coverageArea = await _repo.GetCoverageAreaById(partner.CoverageAreaId);
        var coverageAreaDto = _mapper.Map<CoverageAreaDto>(coverageArea);

        result.Address = addressDto;
        result.CoverageArea = coverageAreaDto;
        
        return Result<PartnerDto>.Success(result);
    }

    
}
