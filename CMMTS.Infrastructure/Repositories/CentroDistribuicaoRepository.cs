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

        public void Add(distribution_centers centroDistribuicao)
        {
            InsertAsync(centroDistribuicao).Wait();
        }

        public IEnumerable<distribution_centers> GetAll()
        {
            string sql = "SELECT * FROM distribution_centers";

            return ExecuteQueryList<distribution_centers>(sql);
        }
    }
}