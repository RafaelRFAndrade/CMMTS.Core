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

        public void Add(Waypoint waypoint)
        {
            waypoint.Codigo = Guid.NewGuid().ToString();

            InsertAsync(waypoint).Wait();
        }

        public IEnumerable<Waypoint> GetAll()
        {
            string sql = "SELECT * FROM waypoints";

            return ExecuteQueryList<Waypoint>(sql);
        }
    }
}
