using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using CMMTS.Domain.Messaging.Requests;
using CMMTS.Domain.Messaging.Responses;
using Microsoft.IdentityModel.Tokens;

namespace CMMTS.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> BuscarUsuarios() 
        {
            var usuarios = _usuarioRepository.GetAll();

            if (!usuarios.Any())
                throw new Exception("Não há usuários");

            return usuarios;
        }

        public LoginResponse LogarUsuario(UsuarioLoginRequest request)
        {
            ValidarLogin(request.nome, request.senha);

            var usuario = _usuarioRepository.BuscarPorNome(request.nome);

            if (usuario == null)
                throw new Exception("Usuário não existe");

            if (usuario.Senha != request.senha)
                throw new Exception("Senha inválida");

            return new LoginResponse
            {
                Successo = true
            };
        } 

        private void ValidarLogin(string nome, string senha)
        {
            if (nome.IsNullOrEmpty())
                throw new Exception("Nome do usuário faltando");

            if (senha.IsNullOrEmpty())
                throw new Exception("Senha do usuário não informada");
        }
    }
}
