using System.Data;
using System.Data.SqlClient;
using Aurum.Infrastructure.Presistence;
using Dapper;
using Microsoft.Extensions.Options;

namespace Aurum.Infrastructure;

public class DapperContext
{
    private readonly DapperSettings _dapperSettings;

    public DapperContext(IOptions<DapperSettings> DapperSettings)
    {
        _dapperSettings = DapperSettings.Value;
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_dapperSettings.SqlServer);

}



