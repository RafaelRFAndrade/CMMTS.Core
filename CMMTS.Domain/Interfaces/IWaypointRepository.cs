using CMMTS.Domain.Entities;

namespace CMMTS.Domain.Interfaces
{
    public interface IWaypointRepository
    {
        void Add(waypoints waypoint);
        IEnumerable<waypoints> GetAll();
    }
}