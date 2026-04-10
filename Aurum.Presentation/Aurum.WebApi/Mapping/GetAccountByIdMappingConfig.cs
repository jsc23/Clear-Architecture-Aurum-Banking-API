using Aurum.Application.Customers.Response.Queries;
using Aurum.Contracts.Accounts;
using Mapster;

namespace Aurum.Api.Mapping;

public class GetAccountByIdMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetTransactionsByAccIdResult, GetTransactionsByAccIdResultResponse>()
            .Map(dest => dest.Transactions, src => src.Account);

    }
}
