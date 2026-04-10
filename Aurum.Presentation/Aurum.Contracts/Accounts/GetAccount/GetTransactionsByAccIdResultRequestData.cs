using System;
namespace Aurum.Contracts.Accounts;

public record GetTransactionsByAccIdResultRequestData(
    Guid UserId,
    int AccountId);


