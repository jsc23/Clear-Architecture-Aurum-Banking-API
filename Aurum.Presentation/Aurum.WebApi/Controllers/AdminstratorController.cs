using Aurum.Application.Adminstrator;
using Aurum.Application.Customers.Commands.AddAccountCredit;
using Aurum.Contracts.Adminstrator;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aurum.Api.Controllers;

[ApiController]
[Authorize(Roles = "admin")]
[Route("/admin")]
public class AdminstratorController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AdminstratorController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost("credit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAccountCredit(AddAccountCreditRequest request)
    {
        var command = _mapper.Map<AddAccountCreditCommand>(request);
        var authResult = await _mediator.Send(command);

        var response = _mapper.Map<AddAccountCreditResponse>(authResult);

        return Ok(response);
    }

    [HttpPost("customer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> NewCustomerAccount(NewCustomerAccountRequest request)
    {
        var command = _mapper.Map<NewCustomerAccountCommand>(request);
        var authResult = await _mediator.Send(command);

        var response = _mapper.Map<NewCustomerAccountResponse>(authResult);

        return Ok(response);
    }
}
