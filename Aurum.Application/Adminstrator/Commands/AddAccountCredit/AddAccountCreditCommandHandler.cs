using Aurum.Application.Common.Errors;
using Aurum.Application.Common.Interfaces.Persistence;
using Aurum.Application.Customers.Response.Commands;
using Aurum.Domain.Aggregates;
using Domain.Domains;
using Domain.Models;
using MediatR;

namespace Aurum.Application.Customers.Commands.AddAccountCredit;

public class AddAccountCreditCommandHandler : IRequestHandler<AddAccountCreditCommand, AddAccountCreditResult>
{
    private readonly IAdminstratorRepository _adminstratorRepository;

    public AddAccountCreditCommandHandler(IAdminstratorRepository adminstratorRepository)
    {
        _adminstratorRepository = adminstratorRepository;
    }

    public async Task<AddAccountCreditResult> Handle(AddAccountCreditCommand request, CancellationToken cancellationToken)
    {
        var result = await _adminstratorRepository.AddAccountCredit(request.AccountId,request.Amount);
        if (result is not TransferAggregate transferDetails)
        {
            throw new InternalServerError();
        }
        return new AddAccountCreditResult(result);
    }
}

