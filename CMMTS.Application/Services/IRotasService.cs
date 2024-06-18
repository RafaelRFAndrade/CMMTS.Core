using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;

namespace CMMTS.Application.Services
{
    public interface IRotasService
    {
        IEnumerable<routes> BuscarRotas(DateTime? data);
        CodResponse AdicionarRota(CadastrarRotaRequest cadastrarRota);
        ResponseBase DeletarRota(string codigoRota);
    }
}
