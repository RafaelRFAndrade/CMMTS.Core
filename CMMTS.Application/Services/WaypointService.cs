using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;

namespace CMMTS.Application.Services
{
    public class WaypointService : IWaypointService
    {
        private readonly IWaypointRepository _waypointRepository;

        public WaypointService(IWaypointRepository waypointRepository)
        {
            _waypointRepository = waypointRepository;
        }

        public IEnumerable<Waypoint> BuscarWaypoints()
        {
            var waypoints = _waypointRepository.GetAll();

            if (waypoints == null)
                throw new Exception("Não há waypoints cadastrados");

            return waypoints;
        }

        public ResponseBase AdicionarWaypoint(CadastrarWaypointRequest cadastrarWaypoint)
        {
            //ValidarWaypoint(cadastrarWaypoint)
            var waypoint = new Waypoint
            {
                Nome = cadastrarWaypoint.Nome,
                Numero = cadastrarWaypoint.Numero,
                Latitude = cadastrarWaypoint.Latitude,
                Longitude = cadastrarWaypoint.Longitude
            };

            _waypointRepository.Add(waypoint);

            return new ResponseBase { Successo = true };
        }
    }
}
