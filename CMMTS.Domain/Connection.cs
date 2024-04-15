using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CMMTS.Domain
{
    public class Connection
    {
        public IConfiguration _configuration;

        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            return _configuration.GetSection("Connection").GetSection("ConnectionString").Value;
        }

        public T ExecuteQuery<T>(string sql)
        {
            using (var con = new SqlConnection(GetConnection()))
            {
                return con.QueryFirstOrDefault<T>(sql);
            }
        }

        public IEnumerable<T> ExecuteQueryList<T>(string sql)
        {
            using (var con = new SqlConnection(GetConnection()))
            {
                return con.Query<T>(sql);
            }
        }
    }
}
