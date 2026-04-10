using System;
using System.ComponentModel.DataAnnotations;

namespace Aurum.Contracts.Accounts;

public record CreateAccountRequest(
    int AccountTypesId,
    string Frequency);


