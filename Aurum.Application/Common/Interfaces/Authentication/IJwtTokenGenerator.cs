using System;
using Domain.Domains;

namespace Aurum.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

