using CMMTS.Domain.Entities;
using CMMTS.Domain.RawQueries;

namespace CMMTS.Domain.Interfaces
{
    public interface IWaypointRepository
    {
        void Add(waypoints waypoint);
        IEnumerable<waypoints> GetAll();
        void AtualizarCodigoRota(List<string> codigoWaypoint, string codigoRota);
        void FinalizarEntrega(string codigoWaypoint);
        void LimparRotaWaypoints(string codigoRota);
    }
}