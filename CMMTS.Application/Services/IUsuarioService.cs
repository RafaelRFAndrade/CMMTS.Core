using CMMTS.Domain.Entities;
using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;

namespace CMMTS.Application.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuarios> BuscarUsuarios();
        ResponseBase LogarUsuario(UsuarioLoginRequest request);
        ResponseBase CadastrarUsuario(CadastrarUsuarioRequest request);
    }
}
