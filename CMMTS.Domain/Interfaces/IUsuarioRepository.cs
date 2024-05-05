using CMMTS.Domain.Entities;

namespace CMMTS.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario BuscarUsuarioPorNickname(string nome);
        void Add(Usuario usuario);
        IEnumerable<Usuario> GetAll();
        int? VerificarExistenciaUsuario(string nome, string email);
    }
}
