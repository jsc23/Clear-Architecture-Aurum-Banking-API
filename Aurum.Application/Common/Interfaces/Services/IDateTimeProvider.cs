using System;
namespace Aurum.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}

