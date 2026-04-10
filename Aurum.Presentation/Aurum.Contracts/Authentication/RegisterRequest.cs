using System;
using System.ComponentModel.DataAnnotations;

namespace Aurum.Contracts.Authentication;

public record RegisterRequest(
	[Required]
	string Email,
	[Required]
    string Password,
	[Required]
    string Role
);

