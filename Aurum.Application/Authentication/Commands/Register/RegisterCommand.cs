using Aurum.Application.Authentication.Common;
using MediatR;

namespace Aurum.Application.Services.Commands.Register;

public record RegisterCommand(
    string Email,
    string Password,
    string Role): IRequest<AuthenticationResult>;

