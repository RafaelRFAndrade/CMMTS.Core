using CMMTS.Domain.Entities;
using CMMTS.Domain.Messaging.Requests;
using CMMTS.Domain.Messaging.Responses;

namespace CMMTS.Application.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> BuscarUsuarios();
        ResponseBase LogarUsuario(UsuarioLoginRequest request);
        ResponseBase CadastrarUsuario(CadastrarUsuarioRequest request);
    }
}
