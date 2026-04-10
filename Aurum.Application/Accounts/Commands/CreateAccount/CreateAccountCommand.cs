using Aurum.Application.Accounts.Response.Commands;
using Aurum.Application.Customers.Response.Commands;
using MediatR;

namespace Aurum.Application.Accounts.Commands;

public record CreateAccountCommand(
    Guid UserId,
    string Frequency,
    int AccountTypesId
    ) : IRequest<CreateAccountResult>;

