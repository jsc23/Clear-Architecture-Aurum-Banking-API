using System;
namespace Aurum.Contracts.Authentication;

public record LoginRequest(
string Email,
string Password);


