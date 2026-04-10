using Aurum.Application.Accounts.Response.Commands;
using Aurum.Contracts.Transactions;
using Mapster;

namespace Aurum.Api.Mapping;

public class TransferMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TransferResult, TransferResponse>()
            .Map(dest => dest.TransactionId, src => src.Transfer.TransactionId)
            .Map(dest => dest.RetrieverAccount, src => src.Transfer.AccountId)
            .Map(dest => dest.Date, src => src.Transfer.Date)
            .Map(dest => dest.Operation, src => src.Transfer.Operation)
            .Map(dest => dest.Amount, src => src.Transfer.Amount)
            .Map(dest => dest.Balance, src => src.Transfer.Balance)
            .Map(dest => dest.SenderAccount, src => src.Transfer.Account);
    }
}

