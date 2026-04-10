using Aurum.Application.Accounts.Queries.GetAccountById;
using Aurum.Application.Common.Errors;
using Aurum.Application.Common.Interfaces.Persistence;
using Aurum.Application.Customers.Response.Queries;
using MediatR;

namespace Aurum.Application.Accounts.Queries.GetTransactionsByAccId;

public class GetAccountByIdHandler : IRequestHandler<GetTransactionsByAccIdQuery, GetTransactionsByAccIdResult>
{
    private readonly ITransactionsRepository _TransactionsRepository;

    public GetAccountByIdHandler(ITransactionsRepository transactionsRepository)
    {
        _TransactionsRepository = transactionsRepository;
    }

    public async Task<GetTransactionsByAccIdResult> Handle(GetTransactionsByAccIdQuery query, CancellationToken cancellationToken)
    {
        if (query.AccountId == 0)
        {
            // return notfound
            throw new InvalidAccount();
        }
        var result = await _TransactionsRepository.GetTransactionsByAccId(query.UserId,query.AccountId);
        if (result is null)
        {
            throw new InvalidAccount();
        }
        return new GetTransactionsByAccIdResult(result);

    }

}

