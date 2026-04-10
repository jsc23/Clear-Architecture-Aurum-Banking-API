using Aurum.Application.Services.Commands.Register;
using Aurum.Application.Services.Queries.Login;
using Aurum.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aurum.Controllers;

  [Route("auth")]
  [ApiController]
  [AllowAnonymous]
  public class AuthenticationController : ControllerBase 
  {
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [Authorize(Roles = "admin")]
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
          var authResult = await _mediator.Send(command);

        var response = _mapper.Map<AuthenticationResponse>(authResult);

        return Ok(response);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        var response = _mapper.Map<AuthenticationResponse>(authResult);

        return Ok(response);
    }

  }
