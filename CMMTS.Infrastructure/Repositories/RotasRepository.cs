using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CMMTS.Infrastructure.Repositories
{
    public class RotasRepository : Connection, IRotasRepository
    {
        public RotasRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Add(routes rota)
        {
            InsertAsync(rota).Wait();
        }

        public IEnumerable<routes> GetAll(DateTime? data)
        {
             string sql = "SELECT * FROM routes";

            if(data != null && data != DateTime.MinValue)
            {
                string dataFormatada = data.Value.ToString("yyyy-MM-dd HH:mm:ss");
                sql += @$" WHERE Data = '{dataFormatada}'";
            }

            return ExecuteQueryList<routes>(sql);
        }
    }
}
