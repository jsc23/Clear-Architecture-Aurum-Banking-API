using System;
using Domain.Domains;

namespace Aurum.Application.Authentication.Common;

public record AuthenticationResult(User user, string Token);


