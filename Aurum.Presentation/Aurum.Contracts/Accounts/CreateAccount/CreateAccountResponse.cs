using System;
using System.ComponentModel.DataAnnotations;

namespace Aurum.Application.Accounts;

public record CreateAccountResponse(
        int AccountId,
        string Frequency,
        DateTime Created,
        decimal Balance,
        int AccountTypesId);


