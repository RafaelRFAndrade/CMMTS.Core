using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;

namespace CMMTS.Application.Services
{
    public class RotasService : IRotasService
    {
        private readonly IRotasRepository _rotasRepository;

        public RotasService(IRotasRepository rotasRepository)
        {
            _rotasRepository = rotasRepository;
        }

        public IEnumerable<Rotas> BuscarRotas()
        {
            var rotas = _rotasRepository.GetAll();

            if (rotas == null)
                throw new Exception("Não há rotas cadastradas");

            return rotas;
        }

        public ResponseBase AdicionarRota(CadastrarRotaRequest cadastrarRota)
        {
            //ValidarRota(cadastrarRota)

            var rota = new Rotas
            {
                CodigoCentroDistribuicao = cadastrarRota.CodigoCentroDistribuicao,
                WaypointsJson = cadastrarRota.WaypointsJson,
                TipoRota = cadastrarRota.TipoRota
            };

            _rotasRepository.Add(rota);

            return new ResponseBase { Successo = true };
        }
    }
}
