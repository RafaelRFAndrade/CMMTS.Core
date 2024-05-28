using CMMTS.Domain.Entities;

namespace CMMTS.Application.Messaging.Requests
{
    public class RoteirizarWaypointsRequest
    {
        public string CodigoRota { get; set; }
        public List<waypoints> Waypoints { get; set; }

    }
}
