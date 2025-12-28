using ApiRestfulCSharp.Api.Controllers.Cars.Requests;
using ApiRestfulCSharp.Application.Cars.Commands.Create;
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
}