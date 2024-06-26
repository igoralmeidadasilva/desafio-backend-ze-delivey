namespace Delivery.Presentation.Controllers;

[Route("/api/[controller]")]
[ApiController]
public sealed class PartnersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PartnersController> _logger;
    private readonly ZeDeliveryDbContext _context;
    
    public PartnersController(IMediator mediator, ILogger<PartnersController> logger, ZeDeliveryDbContext context)
    {
        _mediator = mediator;
        _logger = logger;
        _context = context;
    }

    [HttpPost(nameof(CreatePartner))]
    public async Task<ActionResult<int>> CreatePartner([FromBody]CreatePartnerCommand request)
    {
        try
        {
            var response = await _mediator.Send(request);
            if(response.IsFailure)
            {
                return BadRequest(response.Error);
            }
            return Created("Success! Partner receive ID: {id}", response.Data);
        }
        catch(Exception ex)
        {
            _logger.LogError("Error in class {className} for method {methodName}: {ex}", nameof(PartnersController), nameof(CreatePartner), ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet(nameof(PartnerById))]
    public async Task<ActionResult<PartnerDto>> PartnerById([FromQuery]GetPartnerByIdQuery request)
    {
        try
        {
            _logger.LogInformation(
                "Start {@MethodName}: Fetching Partner with Id {@PartnerIOd}",
                nameof(PartnersController),
                request.Id);
                
            Result<PartnerDto> response = await _mediator.Send(request);
            if(response.IsFailure)
            {
                return NotFound(response.Error);
            }

            return Ok(response.Data);
        }
        catch(Exception ex)
        {
            _logger.LogError("Error in class {className} for method {methodName}: {ex}", nameof(PartnersController), nameof(PartnerById), ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    } 

    [HttpGet(nameof(NearestPartnerInCoverageArea))]
    public async Task<ActionResult<IEnumerable<PartnerDto>>> NearestPartnerInCoverageArea([FromQuery]GetNearestPartnerInCoverageAreaQuery request)
    {
        try
        {
            // Longitude de testes: -43.301087 
            // Latitude de testes: -23.012689 
            Result<PartnerDto> response = await _mediator.Send(request);
            if(response.IsFailure)
            {
                return NotFound(response.Error);
            }
            return Ok(response.Data);
        }
        catch(Exception ex)
        {
            _logger.LogError("Error in class {className} for method {methodName}: {ex}", nameof(PartnersController), nameof(NearestPartnerInCoverageArea), ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

