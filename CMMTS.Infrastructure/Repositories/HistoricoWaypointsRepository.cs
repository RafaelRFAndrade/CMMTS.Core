using CMMTS.Domain.Entities;
using CMMTS.Domain.Enums;
using CMMTS.Domain.Interfaces;
using CMMTS.Domain.RawQueries;
using Microsoft.Extensions.Configuration;

namespace CMMTS.Infrastructure.Repositories
{
    public class HistoricoWaypointsRepository : Connection, IHistoricoWaypointsRepository
    {
        public HistoricoWaypointsRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void Add(HistoricoWaypoints historicoWaypoints)
        {
            InsertAsync(historicoWaypoints).Wait();
        }

        public void AtualizarHistoricos(List<string> waypointsCodigos, SituacaoEntrega situacaoEntrega)
        {
            string codigosConcatenados = string.Join("', '", waypointsCodigos.Select(w => w).ToList());

            string sql = @$"UPDATE
                                HistoricoWaypoints
                            SET
                                Situacao = {(int)situacaoEntrega},
                                DtSituacao = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'
                            WHERE 
                                CodigoWaypoint IN ('{codigosConcatenados}')
                               ";

            ExecuteQueryAsync(sql).Wait();
        }

        public DashboardRawQuery ObterDashboard()
        {
            string sql = $@"
                SELECT 
                    SUM(CASE WHEN Situacao = {(int)SituacaoEntrega.Iniciada} THEN 1 ELSE 0 END) as 'NaoEntregues',
                    SUM(CASE WHEN Situacao = {(int)SituacaoEntrega.EmAndamento} THEN 1 ELSE 0 END) as 'EmAndamento',
                    SUM(CASE WHEN Situacao = {(int)SituacaoEntrega.Finalizada} THEN 1 ELSE 0 END) as 'Entregues',
                    SUM(CASE WHEN Situacao = 3 AND CAST(DtSituacao AS DATE) = CAST('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' AS DATE) THEN 1 ELSE 0 END) as 'EntreguesHoje'
                FROM HistoricoWaypoints";

            return ExecuteQuery<DashboardRawQuery>(sql);
        }

        public void AtualizarHistorico(string codigo, SituacaoEntrega situacaoEntrega)
        {
            string sql = @$"UPDATE
                                HistoricoWaypoints
                            SET
                                Situacao = {(int)situacaoEntrega},
                                DtSituacao = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'
                            WHERE 
                                CodigoWaypoint = ('{codigo}')
                               ";

            ExecuteQueryAsync(sql).Wait();
        }
    }
}
