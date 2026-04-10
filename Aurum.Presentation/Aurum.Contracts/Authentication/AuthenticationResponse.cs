using System;
namespace Aurum.Contracts.Authentication;

public record AuthenticationResponse(
		Guid userId,
		string Email,
		string Role,
		string Token);