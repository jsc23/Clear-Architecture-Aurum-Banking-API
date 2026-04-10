using Aurum.Domain.Aggregates;

namespace Aurum.Application.Customers.Response.Queries;

public record GetTransactionsByAccIdResult(IEnumerable<AccountAggregate> Account);


