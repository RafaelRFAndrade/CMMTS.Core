using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using System.Data;

namespace CMMTS.Application.Services
{
    public class RotasService : IRotasService
    {
        private readonly IRotasRepository _rotasRepository;
        private readonly IWaypointRepository _waypointRepository;

        public RotasService(IRotasRepository rotasRepository, IWaypointRepository waypointRepository)
        {
            _rotasRepository = rotasRepository;
            _waypointRepository = waypointRepository;
        }

        public IEnumerable<routes> BuscarRotas(DateTime? data)
        {
            return _rotasRepository.GetAll(data);
        }

        public CodResponse AdicionarRota(CadastrarRotaRequest cadastrarRota)
        {
            //ValidarRota(cadastrarRota)

            var rota = new routes
            {
                Codigo = Guid.NewGuid().ToString(),
                PlaceIdDestino = cadastrarRota.PlaceIdDestino,
                PlaceIdOrigem = cadastrarRota.PlaceIdOrigem,
                TipoRota = cadastrarRota.TipoRota,
                Data = cadastrarRota.DataRota
            };

            _rotasRepository.Add(rota);

            return new CodResponse { Successo = true, Codigo = rota.Codigo };
        }

        public ResponseBase DeletarRota(string codigoRota)
        {
            _rotasRepository.DeletarRota(codigoRota);

            _waypointRepository.LimparRotaWaypoints(codigoRota);

            return new ResponseBase { Successo = true };
        }
    }
}
