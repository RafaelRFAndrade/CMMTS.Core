using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
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

        public IEnumerable<Usuarios> BuscarUsuarios() 
        {
            var usuarios = _usuarioRepository.GetAll();

            if (!usuarios.Any())
                throw new Exception("Não há usuários");

            return usuarios;
        }

        public ResponseBase LogarUsuario(UsuarioLoginRequest request)
        {
            ValidarLogin(request.nickname, request.senha);

            var usuario = _usuarioRepository.BuscarUsuarioPorNickname(request.nickname);

            if (usuario == null)
                throw new Exception("Usuário não existe");

            if (usuario.Senha != request.senha)
                throw new Exception("Senha inválida");

            return new ResponseBase
            {
                Successo = true
            };
        }

        public ResponseBase AtualizarUsuario(Usuarios usuario)
        {
            _usuarioRepository.AtualizarUsuario(usuario);

            return new ResponseBase
            {
                Successo = true
            };
        }

        public ResponseBase CadastrarUsuario(CadastrarUsuarioRequest request)
        {
            ValidarCadastro(request);

            var usuario = new Usuarios
            {
                Codigo = Guid.NewGuid().ToString(),
                Email = request.Email,
                Nome = request.Nome,
                Nickname = request.NickName,
                TipoAcesso = request.TipoAcesso,
                Senha = request.Senha,
                Status = true
            };

            _usuarioRepository.Add(usuario);

            return new ResponseBase
            {
                Successo = true
            };
        }

        private void ValidarCadastro(CadastrarUsuarioRequest request)
        {
            if (request.Senha.IsNullOrEmpty() || request.Nome.IsNullOrEmpty() || 
                request.TipoAcesso == null || request.NickName.IsNullOrEmpty() || 
                request.Email.IsNullOrEmpty())
                    throw new Exception("Valores ausentes");

            var existenciaUsuario = _usuarioRepository.VerificarExistenciaUsuario(request.NickName, request.Email);

            if (existenciaUsuario != null && existenciaUsuario != 0)
                throw new Exception("Usuário já cadastrado");
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
