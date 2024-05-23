using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;

namespace CMMTS.Application.Services
{
    public interface ICentroDistribuicaoService
    {
        IEnumerable<distribution_centers> BuscarCentros();
        ResponseBase AdicionarCentro(CadastrarCentroRequest centroDistribuicao);
    }
}
