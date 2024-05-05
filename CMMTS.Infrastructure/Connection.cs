using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CMMTS.Infrastructure
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

        public async Task InsertAsync<T>(T entity) where T : class
        {
            using (var connection = new SqlConnection(GetConnection()))
            {
                var query = $"INSERT INTO {typeof(T).Name}s ({string.Join(", ", typeof(T).GetProperties().Select(p => p.Name))}) VALUES (@{string.Join(", @", typeof(T).GetProperties().Select(p => p.Name))})";
                await connection.ExecuteAsync(query, entity);
            }
        }
    }
}
