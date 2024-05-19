using CMMTS.Domain.Entities;

namespace CMMTS.Domain.Interfaces
{
    public interface ICentroDistribuicaoRepository
    {
        IEnumerable<CentroDistribuicao> GetAll();
        void Add(CentroDistribuicao centroDistribuicao);
    }
}
