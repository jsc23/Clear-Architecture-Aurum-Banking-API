using System;
using Aurum.Application.Customers.Response.Queries;
using MediatR;

namespace Aurum.Application.Accounts.Queries.GetAccounts;

public record GetAccountsQuery(Guid UserId) : IRequest<GetAccountsResult>;
