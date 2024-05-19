﻿using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CMMTS.Infrastructure.Repositories
{
    public class RotasRepository : Connection, IRotasRepository
    {
        public RotasRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Add(Rotas rota)
        {
            rota.Codigo = Guid.NewGuid().ToString();

            InsertAsync(rota).Wait();
        }

        public IEnumerable<Rotas> GetAll()
        {
            string sql = "SELECT * FROM routes";

            return ExecuteQueryList<Rotas>(sql);
        }
    }
}
