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

        public RotasResponse AdicionarRota(CadastrarRotaRequest cadastrarRota)
        {
            //ValidarRota(cadastrarRota)

            var rota = new routes
            {
                Codigo = Guid.NewGuid().ToString(),
                PlaceIdDestino = cadastrarRota.PlaceIdDestino,
                PlaceIdOrigem = cadastrarRota.PlaceIdOrigem,
                TipoRota = cadastrarRota.TipoRota
            };

            _rotasRepository.Add(rota);

            return new RotasResponse { Successo = true, Codigo = rota.Codigo };
        }
    }
}
