namespace Delivery.Application.Querys.GetPartnerById;

public sealed class GetPartnerByIdQueryHandler : IRequestHandler<GetPartnerByIdQuery, Result<PartnerDto>>
{
    private readonly ILogger<GetPartnerByIdQueryHandler> _logger;
    private readonly IPartnerRepository _repo;
    private readonly IMapper _mapper;

    public GetPartnerByIdQueryHandler(ILogger<GetPartnerByIdQueryHandler> logger, IPartnerRepository repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Result<PartnerDto>> Handle(GetPartnerByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repo.GetPartnerById(request.Id);

        if(result is null)
        {
            _logger.LogError("Error in fetching partner with id {PartnerId} em handler {className}", request.Id, nameof(GetPartnerByIdQueryHandler));
            return Result<PartnerDto>.Failure(PartnerErrors.PartnerNotFound(request.Id));
        }

        PartnerDto partner = _mapper.Map<PartnerDto>(result);
        
        return Result<PartnerDto>.Success(partner);
    }
    
}
