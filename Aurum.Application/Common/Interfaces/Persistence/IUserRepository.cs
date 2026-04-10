using System;
using Domain.Domains;

namespace Aurum.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task <User?>GetUserByEmail(string email);

    void Add(User user);
}

