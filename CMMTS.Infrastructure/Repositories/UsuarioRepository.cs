﻿using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CMMTS.Infrastructure.Repositories
{
    public class UsuarioRepository : Connection, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Usuarios usuario)
        {            
            InsertAsync(usuario).Wait();
        }

        public IEnumerable<Usuarios> GetAll()
        {
            string sql = "SELECT * FROM Usuarios";

            return ExecuteQueryList<Usuarios>(sql);
        }

        public Usuarios BuscarUsuarioPorNickname(string nickname) 
        {
            string sql = @$"SELECT * FROM Usuarios WHERE Nickname = '{nickname}'";

            return ExecuteQuery<Usuarios>(sql);
        }

        public int? VerificarExistenciaUsuario(string nome, string email)
        {
            string sql = @$"SELECT 
                                COUNT(*)
                            FROM
                                Usuarios
                            WHERE
                                Nickname = '{nome}'
                            OR
                                Email = '{email}'";

            return ExecuteQuery<int?>(sql);
        }
    }
}
