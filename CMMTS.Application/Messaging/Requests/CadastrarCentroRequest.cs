namespace CMMTS.Application.Messaging.Requests
{
    public class CadastrarCentroRequest
    {
        public string Nome { get; set; }
        public int Numero { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
