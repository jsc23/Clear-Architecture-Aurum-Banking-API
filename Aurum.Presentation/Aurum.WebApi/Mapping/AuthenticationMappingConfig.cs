using System;
using Aurum.Application.Authentication.Common;
using Aurum.Contracts.Authentication;
using Mapster;

namespace Aurum.Api.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.user)
            .Map(dest => dest.userId, src => src.user.UserId);
            
    }
}


