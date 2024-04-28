using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;

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
    }
}
