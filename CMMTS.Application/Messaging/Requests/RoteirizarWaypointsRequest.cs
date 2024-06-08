using CMMTS.Domain.Entities;

namespace CMMTS.Application.Messaging.Requests
{
    public class RoteirizarWaypointsRequest
    {
        public string CodigoRota { get; set; }
        public List<string> CodigoWaypoint { get; set; }
    }
}
