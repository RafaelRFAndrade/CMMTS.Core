using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;

namespace CMMTS.Application.Services
{
    public interface IRotasService
    {
        IEnumerable<routes> BuscarRotas();
        RotasResponse AdicionarRota(CadastrarRotaRequest cadastrarRota);
    }
}
