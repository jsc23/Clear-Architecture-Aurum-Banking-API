using System.Text;
using Aurum.Application.Accounts.Response.Commands;
using Aurum.Application.Common.Errors;
using Aurum.Application.Common.Interfaces.Persistence;
using MediatR;

namespace Aurum.Application.Transactions.Commands.Transfer;

public class TransferCommandHandler : IRequestHandler<TransferCommand, TransferResult>
{
    private readonly ITransactionsRepository _transactionRepository;

    public TransferCommandHandler(ITransactionsRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<TransferResult> Handle(TransferCommand request, CancellationToken cancellationToken)
    {
        var operationId = request.Operation;
        StringBuilder operation = new StringBuilder();
        if (operationId == 1 | operationId ==2)
        {
            if (request.Amount<1)
            {
                throw new InvalidTransferAmount();
            }
            else
            {
                if (operationId == 1)
                {
                    operation.Append("Transfer Between Accounts");
                }
                else
                    operation.Append("Remittance to Another Bank");
            }
        }
        else
        {
            throw new InvalidTransferOperation();
        }
        string Operation = operation.ToString();
        var result =  await _transactionRepository.Transfer(request.UserId,request.AccountId, Operation,request.Amount, request.Account);

        return new TransferResult(result);
    }
}

