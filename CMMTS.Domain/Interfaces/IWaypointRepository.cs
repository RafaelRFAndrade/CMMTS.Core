using CMMTS.Domain.Entities;

namespace CMMTS.Domain.Interfaces
{
    public interface IWaypointRepository
    {
        void Add(Waypoint waypoint);
        IEnumerable<Waypoint> GetAll();
    }
}