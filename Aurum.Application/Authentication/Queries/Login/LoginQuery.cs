using Aurum.Application.Authentication.Common;
using MediatR;

namespace Aurum.Application.Services.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<AuthenticationResult>;

