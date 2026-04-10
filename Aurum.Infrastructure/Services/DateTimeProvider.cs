using System;
using Aurum.Application.Common.Interfaces.Services;

namespace Aurum.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

