using CMMTS.Domain.Entities;

namespace CMMTS.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario BuscarPorNome(string nome);
        void Add(Usuario usuario);
        IEnumerable<Usuario> GetAll();
    }
}
