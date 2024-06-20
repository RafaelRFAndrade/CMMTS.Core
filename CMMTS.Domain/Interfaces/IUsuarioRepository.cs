using CMMTS.Domain.Entities;

namespace CMMTS.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuarios BuscarUsuarioPorNickname(string nome);
        void Add(Usuarios usuario);
        IEnumerable<Usuarios> GetAll();
        int? VerificarExistenciaUsuario(string nome, string email);
        void DeletarUsuarioPorNickname(string nickname);
        void AtualizarUsuario(Usuarios usuario);
    }
}