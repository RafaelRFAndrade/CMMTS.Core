using CMMTS.Domain.Enums;

namespace CMMTS.Application.Messaging.Requests
{
    public class CadastrarRotaRequest
    {
        public string CodigoCentroDistribuicao { get; set; }
        public string WaypointsJson { get; set; }
        public TipoRota TipoRota { get; set; }
    }
}
