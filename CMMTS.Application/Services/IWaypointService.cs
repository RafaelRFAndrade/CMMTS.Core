using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;

namespace CMMTS.Application.Services
{
    public interface IWaypointService
    {
        IEnumerable<waypoints> BuscarWaypoints();
        ResponseBase AdicionarWaypoint(CadastrarWaypointRequest cadastrarWaypoint);
        ResponseBase RoteirizarWaypoints(List<string> codigoWaypoint, string codigoRota);
    }
}
