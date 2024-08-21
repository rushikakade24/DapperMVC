using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperCRUDProduct.DataAccessLayer
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration config;

        public SqlDataAccess(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<IEnumerable<T>> GetData<T,P> (string spName, P parameters, string connectionId ="dbcs")
        {
            using IDbConnection connection = new SqlConnection (config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(spName,parameters,commandType:CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string spName, T parameters, string connectionId = "dbcs")
        {
            using IDbConnection connection = new SqlConnection(config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
