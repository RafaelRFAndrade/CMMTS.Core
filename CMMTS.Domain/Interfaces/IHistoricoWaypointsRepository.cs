using CMMTS.Domain.Entities;
using CMMTS.Domain.Enums;
using CMMTS.Domain.RawQueries;

namespace CMMTS.Domain.Interfaces
{
    public interface IHistoricoWaypointsRepository
    {
        void Add(HistoricoWaypoints historicoWaypoints);
        void AtualizarHistoricos(List<string> waypointsCodigos, SituacaoEntrega situacaoEntrega);
        DashboardRawQuery ObterDashboard();
        void AtualizarHistorico(string codigo, SituacaoEntrega situacaoEntrega);
    }
}
