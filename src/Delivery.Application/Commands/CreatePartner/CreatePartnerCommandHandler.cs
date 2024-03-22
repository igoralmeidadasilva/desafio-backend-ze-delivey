namespace Delivery.Application.Commands.CreatePartner;

public class CreatePartnerCommandHandler : IRequestHandler<CreatePartnerCommand, Result<int>>
{
    private readonly ILogger<CreatePartnerCommandHandler> _logger;
    private readonly IPartnerRepository _repo;
    private IMapper _mapper;

    public CreatePartnerCommandHandler(ILogger<CreatePartnerCommandHandler> logger, IPartnerRepository repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
    {
        var mappedRequest = _mapper.Map<Partner>(request);
        var response = await _repo.InsertPartner(mappedRequest);
        return Result<int>.Success(response);
    }
}
