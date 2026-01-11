using ApiRestfulCSharp.Api.Controllers.Cars.Responses;
using ApiRestfulCSharp.Application.Cars.Queries.GetById;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestfulCSharp.Api.Controllers.Cars.Controllers.V2;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("2.0")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CarsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/{id}")]
    [ProducesResponseType(typeof(GetByIdCarV2Response), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdV2(Guid id)
    {
        var query = new GetByIdCarQuery(id);
    
        var result = await _mediator.Send(query);
        
        var response  = _mapper.Map<GetByIdCarV2Response>(result);
        
        return Ok(response);
    }
}