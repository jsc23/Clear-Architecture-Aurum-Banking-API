using System;
namespace Aurum.Contracts.Accounts;

public record CreateAccountRequestData(
    Guid UserId,
    string Frequency,
    int AccountTypesId);


