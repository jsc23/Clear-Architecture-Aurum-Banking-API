using Aurum.Domain.Aggregates;
using Domain.Models;

namespace Aurum.Application.Common.Interfaces.Persistence;

public interface IAdminstratorRepository
{
    Task<TransferAggregate> AddAccountCredit(int accountId,decimal amount);
}