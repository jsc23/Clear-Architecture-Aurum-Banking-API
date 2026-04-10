using System;
using Aurum.Application.Customers.Response.Queries;
using MediatR;

namespace Aurum.Application.Accounts.Queries.GetAccountById;

public record GetTransactionsByAccIdQuery(Guid UserId, int AccountId) : IRequest <GetTransactionsByAccIdResult>;


