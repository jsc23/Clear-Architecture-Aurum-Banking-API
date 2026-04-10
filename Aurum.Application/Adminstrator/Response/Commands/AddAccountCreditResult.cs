using Aurum.Domain.Aggregates;

namespace Aurum.Application.Customers.Response.Commands;

public record AddAccountCreditResult(TransferAggregate Transfer);




