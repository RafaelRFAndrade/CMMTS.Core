using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CMMTS.Infrastructure.Repositories
{
    public class WaypointRepository : Connection, IWaypointRepository
    {
        public WaypointRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Add(waypoints waypoint)
        {
            InsertAsync(waypoint).Wait();
        }

        public IEnumerable<waypoints> GetAll()
        {
            string sql = "SELECT * FROM waypoints";

            return ExecuteQueryList<waypoints>(sql);
        }

        public void AtualizarCodigoRota(List<string> waypoints, string codigoRota)
        {
            string codigosConcatenados = string.Join("', '", waypoints.Select(w => w).ToList());

            string sql = @$"UPDATE 
                               waypoints 
                             SET 
                               CodigoRota = '{codigoRota}'
                            WHERE 
                                Codigo IN ('{codigosConcatenados}')";

            ExecuteQueryAsync(sql).Wait();
        }

        public void FinalizarEntrega(string codigoWaypoint)
        {
            string sql = @$"DELETE FROM waypoints WHERE Codigo = '{codigoWaypoint}'";

            ExecuteQueryAsync(sql).Wait();
        }
    }
}
