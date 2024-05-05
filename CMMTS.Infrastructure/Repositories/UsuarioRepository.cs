using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CMMTS.Infrastructure.Repositories
{
    public class UsuarioRepository : Connection, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Usuario usuario)
        {
            usuario.Codigo = Guid.NewGuid();
            InsertAsync(usuario);
        }

        public void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            string sql = "SELECT * FROM dbo.Usuarios";

            return ExecuteQueryList<Usuario>(sql);
        }

        public Usuario BuscarUsuarioPorNickname(string nickname) 
        {
            string sql = @$"SELECT * FROM dbo.Usuarios WHERE Nickname = '{nickname}'";

            return ExecuteQuery<Usuario>(sql);
        }

        public int? VerificarExistenciaUsuario(string nome, string email)
        {
            string sql = @$"SELECT 
                                COUNT(*)
                            FROM
                                dbo.Usuarios 
                            WHERE
                                Nickname = '{nome}'
                            OR
                                Email = '{email}'";

            return ExecuteQuery<int?>(sql);
        }

        public Usuario GetByCode(Guid code)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
