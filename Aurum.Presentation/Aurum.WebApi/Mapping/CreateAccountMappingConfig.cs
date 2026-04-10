using Aurum.Application.Accounts;
using Aurum.Application.Accounts.Response.Commands;
using Aurum.Application.Customers;
using Aurum.Application.Customers.Response.Commands;
using Mapster;

namespace Aurum.Api.Mapping;

public class CreateAccountMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAccountResult, CreateAccountResponse>()
            .Map(dest => dest.AccountId, src => src.Account.AccountId)
            .Map(dest => dest.Frequency, src => src.Account.Frequency)
            .Map(dest => dest.Created, src => src.Account.Created)
            .Map(dest => dest.Balance, src => src.Account.Balance)
            .Map(dest => dest.AccountTypesId, src => src.Account.AccountTypesId);
    }
}


