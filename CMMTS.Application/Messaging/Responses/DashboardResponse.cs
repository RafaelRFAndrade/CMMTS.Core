namespace CMMTS.Application.Messaging.Responses
{
    public class DashboardResponse : ResponseBase
    {
        public int Entregues { get; set; }
        public int NaoEntregues { get; set; }
        public int EmAndamento { get; set; }
        public int EntreguesHoje { get; set; }
    }
}
