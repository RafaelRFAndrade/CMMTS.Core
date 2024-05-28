using CMMTS.Domain.Entities;

namespace CMMTS.Domain.Interfaces
{
    public interface IWaypointRepository
    {
        void Add(waypoints waypoint);
        IEnumerable<waypoints> GetAll();
        void BulkUpdate(List<waypoints> waypoints, string codigoRota);
    }
}