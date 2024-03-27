using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStoreQueryWithDapper.Infrastructure.DATA
{
    public class DapperDbContext
    {
        private readonly IConfiguration _config;
        private readonly string? _dbString;

        public DapperDbContext(IConfiguration config)
        {
            _config = config;
            _dbString = _config.GetConnectionString("DbCon");
        }

        public IDbConnection CreateConnection() => new SqlConnection(this._dbString);
    }
}
