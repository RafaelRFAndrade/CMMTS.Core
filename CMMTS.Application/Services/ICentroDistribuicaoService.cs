using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;

namespace CMMTS.Application.Services
{
    public interface ICentroDistribuicaoService
    {
        IEnumerable<CentroDistribuicao> BuscarCentros();
        ResponseBase AdicionarCentro(CadastrarCentroRequest centroDistribuicao);
    }
}
