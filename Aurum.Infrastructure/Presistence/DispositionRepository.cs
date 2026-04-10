using System;
using Dapper;
using System.Data;
using Aurum.Application.Common.Errors;

namespace Aurum.Infrastructure.Presistence;

public class DispositionRepository : IDispositionRepository
{
    private readonly DapperContext _context;

    public DispositionRepository(DapperContext context)
    {
        _context = context;
    }


    public async Task<int?> GetCustomerIdFromDisposition(Guid userId)
    {
        using (var db = _context.CreateConnection())
        {
            try
            {
                var customerId = await db.QuerySingleAsync<int>("GetCustomerIdDispostion", new { userId }, commandType: CommandType.StoredProcedure);
                return customerId;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

