using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;

namespace CMMTS.Application.Services
{
    public class CentroDistribuicaoService : ICentroDistribuicaoService
    {
        private readonly ICentroDistribuicaoRepository _centroDistribuicaoRepository;

        public CentroDistribuicaoService(ICentroDistribuicaoRepository centroDistribuicaoRepository)
        {
            _centroDistribuicaoRepository = centroDistribuicaoRepository;
        }

        public IEnumerable<distribution_centers> BuscarCentros()
        {
            var centros = _centroDistribuicaoRepository.GetAll();

            if (centros == null)
                throw new Exception("Não há centros cadastrados");

            return centros;
        }

        public ResponseBase AdicionarCentro(CadastrarCentroRequest centroDistribuicao)
        {
            //validarCentro(centroDistribuicao); Ainda deverá ser pensado
            var centro = new distribution_centers
            {
                Nome = centroDistribuicao.Nome,
                Numero = centroDistribuicao.Numero,
                Longitude = centroDistribuicao.Longitude,
                Latitude = centroDistribuicao.Latitude
            };

            _centroDistribuicaoRepository.Add(centro);

            return new ResponseBase { Successo = true };
        }
    }
}
