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

        public RotasService(IRotasRepository rotasRepository)
        {
            _rotasRepository = rotasRepository;
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
    }
}
