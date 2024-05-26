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

        public IEnumerable<routes> BuscarRotas()
        {
            return _rotasRepository.GetAll();
        }

        public ResponseBase AdicionarRota(CadastrarRotaRequest cadastrarRota)
        {
            //ValidarRota(cadastrarRota)

            var rota = new routes
            {
                PlaceIdDestino = cadastrarRota.PlaceIdDestino,
                PlaceIdOrigem = cadastrarRota.PlaceIdOrigem,
                TipoRota = cadastrarRota.TipoRota
            };

            _rotasRepository.Add(rota);

            return new ResponseBase { Successo = true };
        }
    }
}
