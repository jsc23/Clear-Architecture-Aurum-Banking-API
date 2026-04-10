using System;
using System.ComponentModel.DataAnnotations;

namespace Aurum.Contracts.Accounts;

public record GetTransactionsByAccIdResultRequest([Required]int AccountId);


