using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

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
            using (var con = new MySqlConnection(GetConnection()))
            {
                return con.QueryFirstOrDefault<T>(sql);
            }
        }

        public T ExecuteQueryParametrizada<T>(string sql, object parametros = null)
        {
            using (var con = new MySqlConnection(GetConnection()))
            {
                return con.QueryFirstOrDefault<T>(sql, parametros);
            }
        }

        public IEnumerable<T> ExecuteQueryList<T>(string sql)
        {
            using (var con = new MySqlConnection(GetConnection()))
            {
                return con.Query<T>(sql);
            }
        }

        public async Task InsertAsync<T>(T entity) where T : class
        {
            using (var connection = new MySqlConnection(GetConnection()))
            {
                var query = $"INSERT INTO {typeof(T).Name} ({string.Join(", ", typeof(T).GetProperties().Select(p => p.Name))}) VALUES (@{string.Join(", @", typeof(T).GetProperties().Select(p => p.Name))})";
                await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task ExecuteQueryAsync(string sql)
        {
            using (var connection = new MySqlConnection(GetConnection()))
            {
                await connection.ExecuteAsync(sql);
            }
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            using (var connection = new MySqlConnection(GetConnection()))
            {
                var properties = typeof(T).GetProperties()
                                          .Where(p => p.GetValue(entity) != null && p.Name != "Codigo") 
                                          .Select(p => $"{p.Name} = @{p.Name}");

                var keyProperty = typeof(T).GetProperty("Codigo");

                if (keyProperty == null)
                {
                    throw new ArgumentException("A entidade de alguma forma ta sem código.");
                }

                var query = $"UPDATE {typeof(T).Name} SET {string.Join(", ", properties)} WHERE Codigo = @Codigo";

                var parameters = new DynamicParameters(entity);

                parameters.Add("Codigo", keyProperty.GetValue(entity));

                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
