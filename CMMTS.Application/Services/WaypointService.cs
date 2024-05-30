﻿using CMMTS.Application.Messaging.Requests;
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

        public IEnumerable<waypoints> BuscarWaypoints()
        {
            return _waypointRepository.GetAll();
        }

        public ResponseBase AdicionarWaypoint(CadastrarWaypointRequest cadastrarWaypoint)
        {
            //ValidarWaypoint(cadastrarWaypoint)
            var waypoint = new waypoints
            {
                Codigo = Guid.NewGuid().ToString(),
                CodigoRota = cadastrarWaypoint.CodigoRota,
                Nome = cadastrarWaypoint.Nome,
                Numero = cadastrarWaypoint.Numero,
                PlaceIdWaypoint = cadastrarWaypoint.PlaceIdWaypoint
            };

            _waypointRepository.Add(waypoint);

            return new ResponseBase { Successo = true };
        }

        public ResponseBase RoteirizarWaypoints(List<waypoints> waypoints, string codigoRota)
        {
            _waypointRepository.BulkUpdate(waypoints, codigoRota);

            return new ResponseBase { Successo = true };    
        }
    }
}
