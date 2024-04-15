﻿using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace CMMTS.Domain.Repositories
{
    public class UsuarioRepository : Connection, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration) { }

        public void Add(Usuario entity)
        {
            throw new NotImplementedException();
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
