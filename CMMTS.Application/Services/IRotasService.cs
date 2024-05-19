using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;

namespace CMMTS.Application.Services
{
    public interface IRotasService
    {
        IEnumerable<Rotas> BuscarRotas();
        ResponseBase AdicionarRota(CadastrarRotaRequest cadastrarRota);
    }
}
