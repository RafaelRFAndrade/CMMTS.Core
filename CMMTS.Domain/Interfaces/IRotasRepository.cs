﻿using CMMTS.Domain.Entities;

namespace CMMTS.Domain.Interfaces
{
    public interface IRotasRepository
    {
        void Add(routes rota);
        IEnumerable<routes> GetAll(DateTime? data);
        void DeletarRota(string codigoRota);
    }
}