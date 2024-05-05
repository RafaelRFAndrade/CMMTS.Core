using CMMTS.Domain.Enums;

namespace CMMTS.Application.Messaging.Requests
{
    public class CadastrarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Senha { get; set; }
        public TipoAcesso TipoAcesso { get; set; }
    }
}
