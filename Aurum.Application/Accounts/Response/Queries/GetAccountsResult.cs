using Domain.Models;

namespace Aurum.Application.Customers.Response.Queries;

public record GetAccountsResult(IEnumerable<Account> account);

