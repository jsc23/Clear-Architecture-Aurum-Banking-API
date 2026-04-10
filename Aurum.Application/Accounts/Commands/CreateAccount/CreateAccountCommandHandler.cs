using Aurum.Application.Accounts.Response.Commands;
using Aurum.Application.Common.Errors;
using Aurum.Application.Common.Interfaces.Persistence;
using Aurum.Infrastructure.Presistence;
using Domain.Domains;
using Domain.Models;
using MediatR;

namespace Aurum.Application.Accounts.Commands;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResult>
{
    private readonly IAccountsRepository _accountsRepository;
    private readonly IDispositionRepository _dispositionRepository;


    public CreateAccountCommandHandler(IAccountsRepository customerRepository, IDispositionRepository dispositionRepository)
    {
        _accountsRepository = customerRepository;
        _dispositionRepository = dispositionRepository;
    }


    public async Task<CreateAccountResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        if (request.AccountTypesId ==1 && request.Frequency == "")
        {
            throw new RequieredFrequencyForSavingAcc();
        }
        var customerId = await _dispositionRepository.GetCustomerIdFromDisposition(request.UserId);
        if (customerId is null)
        {
            throw new InvalidCustomer();
        }
        var result = await _accountsRepository.CreateAccount(request.UserId, request.Frequency, request.AccountTypesId,customerId);
        if (result is not Account account)
        {
            throw new InvalidFrequency();
        }
        return new CreateAccountResult(result);
    }
}

