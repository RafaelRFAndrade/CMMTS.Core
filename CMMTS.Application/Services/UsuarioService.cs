using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
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

        public LoginResponse LogarUsuario(string nome, string senha)
        {
            ValidarLogin(nome, senha);

            var usuario = _usuarioRepository.BuscarPorNome(nome);

            if (usuario == null)
                throw new Exception("Usuário não existe");

            if (usuario.Senha != senha)
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
