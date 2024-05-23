using CMMTS.Domain.Entities;

namespace CMMTS.Domain.Interfaces
{
    public interface ICentroDistribuicaoRepository
    {
        IEnumerable<distribution_centers> GetAll();
        void Add(distribution_centers centroDistribuicao);
    }
}
