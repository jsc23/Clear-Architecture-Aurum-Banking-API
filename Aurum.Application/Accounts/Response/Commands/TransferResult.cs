using System;
using Aurum.Domain.Aggregates;

namespace Aurum.Application.Accounts.Response.Commands;

public record TransferResult(TransferAggregate Transfer);


