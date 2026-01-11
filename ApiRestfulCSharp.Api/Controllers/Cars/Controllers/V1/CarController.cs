using ApiRestfulCSharp.Api.Controllers.Cars.Requests;
using ApiRestfulCSharp.Api.Controllers.Cars.Responses;
using ApiRestfulCSharp.Application.Cars.Commands.Create;
using ApiRestfulCSharp.Application.Cars.Commands.Delete;
using ApiRestfulCSharp.Application.Cars.Queries.GetAll;
using ApiRestfulCSharp.Application.Cars.Queries.GetById;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestfulCSharp.Api.Controllers.Cars.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
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
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateCarRequest request)
    {
        var command = _mapper.Map<CreateCarCommand>(request);
        var response = await _mediator.Send(command);
        
        return CreatedAtAction(nameof(GetByIdV1), new { id = response }, response); 
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCarsQuery query)
    {
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    [HttpGet("/{id}")]
    [ProducesResponseType(typeof(GetByIdCarResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdV1(Guid id)
    {
        var query = new GetByIdCarQuery(id);
    
        var result = await _mediator.Send(query);

        var summary = _mapper.Map<GetByIdCarResponse>(result);

        return Ok(summary);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteCarCommand(id);

        await _mediator.Send(command);
        
        return NoContent();
    }
}