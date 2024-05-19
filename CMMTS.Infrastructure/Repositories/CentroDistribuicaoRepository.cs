using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CMMTS.Infrastructure.Repositories
{
    public class CentroDistribuicaoRepository : Connection, ICentroDistribuicaoRepository
    {
        public CentroDistribuicaoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Add(CentroDistribuicao centroDistribuicao)
        {
            centroDistribuicao.Codigo = Guid.NewGuid().ToString();

            InsertAsync(centroDistribuicao).Wait();
        }

        public IEnumerable<CentroDistribuicao> GetAll()
        {
            string sql = "SELECT * FROM distribution_centers";

            return ExecuteQueryList<CentroDistribuicao>(sql);
        }
    }
}