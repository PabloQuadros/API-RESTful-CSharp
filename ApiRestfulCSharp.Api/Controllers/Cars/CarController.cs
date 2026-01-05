using ApiRestfulCSharp.Api.Controllers.Cars.Requests;
using ApiRestfulCSharp.Api.Controllers.Cars.Responses;
using ApiRestfulCSharp.Application.Cars.Commands.Create;
using ApiRestfulCSharp.Application.Cars.Queries.GetAll;
using ApiRestfulCSharp.Application.Cars.Queries.GetById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestfulCSharp.Api.Controllers.Cars;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CarsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCarRequest request)
    {
        var command = _mapper.Map<CreateCarCommand>(request);
        var response = await _mediator.Send(command);
        
        return Ok(response); 
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCarsQuery query)
    {
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    [HttpGet("v1/{id}")]
    public async Task<IActionResult> GetByIdV1(Guid id)
    {
        var query = new GetByIdCarQuery(id);
    
        var result = await _mediator.Send(query);

        if (result == null) return NotFound();

        var summary = _mapper.Map<GetByIdCarResponse>(result);

        return Ok(summary);
    }

    [HttpGet("v2/{id}")]
    public async Task<IActionResult> GetByIdV2(Guid id)
    {
        var query = new GetByIdCarQuery(id);
    
        var result = await _mediator.Send(query);

        if (result == null) return NotFound();
        
        var response  = _mapper.Map<GetByIdCarV2Response>(result);
        return Ok(response);
    }
}