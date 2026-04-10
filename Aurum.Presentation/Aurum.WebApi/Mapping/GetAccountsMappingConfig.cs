using Aurum.Application.Accounts;
using Aurum.Application.Customers.Response.Queries;
using Mapster;

namespace Aurum.Api.Mapping;

public class GetAccountsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAccountsResult, GetAccountsResponse>()
            .Map(dest => dest.Accounts, src => src.account);
    }
}
