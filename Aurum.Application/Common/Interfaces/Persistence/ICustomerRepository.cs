using Aurum.Application.Customers.Commands.AddAccountCredit;
using Aurum.Domain.Aggregates;
using Domain.Domains;

namespace Aurum.Application.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    Task<NewCustomerAccountAggregate> NewCustomerAccount(User user, NewCustomerAccountCommand command);
}