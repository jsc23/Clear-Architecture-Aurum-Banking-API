namespace Aurum.Infrastructure.Presistence;

public interface IDispositionRepository
{
    Task<int?> GetCustomerIdFromDisposition(Guid userId);
}