using System;
using System.ComponentModel.DataAnnotations;

namespace Aurum.Contracts.Adminstrator;

public record AddAccountCreditRequest(
    [Required]
    int AccountId,
    decimal Amount);


