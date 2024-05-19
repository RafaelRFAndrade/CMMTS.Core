﻿using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;

namespace CMMTS.Application.Services
{
    public interface IWaypointService
    {
        IEnumerable<Waypoint> BuscarWaypoints();
        ResponseBase AdicionarWaypoint(CadastrarWaypointRequest cadastrarWaypoint);
    }
}
