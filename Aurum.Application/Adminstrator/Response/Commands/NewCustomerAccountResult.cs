using System;
using Aurum.Domain.Aggregates;

namespace Aurum.Application.Adminstrator.Response.Commands;

public record NewCustomerAccountResult(NewCustomerAccountAggregate DispositionCustomerAccount);

