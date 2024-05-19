using CMMTS.Domain.Entities;

namespace CMMTS.Domain.Interfaces
{
    public interface IRotasRepository
    {
        void Add(Rotas rota);
        IEnumerable<Rotas> GetAll();
    }
}