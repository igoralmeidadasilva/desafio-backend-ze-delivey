using Delivery.Application.Querys.GetNearestPartnerInCoverageArea;
using Delivery.Application.Querys.GetPartnerById;
using Delivery.Domain.Dtos;
using Delivery.Domain.Models;
using Delivery.Infrastructure.DataContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet(nameof(PartnerById))]
    public async Task<ActionResult<PartnerDto>> PartnerById([FromQuery]GetPartnerByIdQuery request)
    {
        try
        {
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

