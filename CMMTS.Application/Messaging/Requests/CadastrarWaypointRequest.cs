namespace CMMTS.Application.Messaging.Requests
{
    public class CadastrarWaypointRequest
    {
        public string CodigoRota { get; set; }
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string PlaceIdWaypoint { get; set; }
    }
}
