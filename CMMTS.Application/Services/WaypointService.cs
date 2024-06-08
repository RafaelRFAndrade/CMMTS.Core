using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Messaging.Responses;
using CMMTS.Domain.Entities;
using CMMTS.Domain.Enums;
using CMMTS.Domain.Interfaces;

namespace CMMTS.Application.Services
{
    public class WaypointService : IWaypointService
    {
        private readonly IWaypointRepository _waypointRepository;
        private readonly IHistoricoWaypointsRepository _historicoWaypointsRepository;

        public WaypointService(IWaypointRepository waypointRepository, IHistoricoWaypointsRepository historyWaypointsRepository)
        {
            _waypointRepository = waypointRepository;
            _historicoWaypointsRepository = historyWaypointsRepository;
        }

        public IEnumerable<waypoints> BuscarWaypoints()
        {
            return _waypointRepository.GetAll();
        }

        public ResponseBase AdicionarWaypoint(CadastrarWaypointRequest cadastrarWaypoint)
        {
            //ValidarWaypoint(cadastrarWaypoint)
            var waypoint = new waypoints
            {
                Codigo = Guid.NewGuid().ToString(),
                CodigoRota = cadastrarWaypoint.CodigoRota,
                Nome = cadastrarWaypoint.Nome,
                Numero = cadastrarWaypoint.Numero,
                PlaceIdWaypoint = cadastrarWaypoint.PlaceIdWaypoint
            };

            var logWaypoint = new HistoricoWaypoints
            {
                Codigo = Guid.NewGuid().ToString(),
                CodigoWaypoint = waypoint.Codigo,
                Situacao = SituacaoEntrega.Iniciada,
                DtSituacao = DateTime.Now,
                DtInclusao = DateTime.Now
            };
            //um dia desses eu vou meter uma transaction aq kk mas falta infra Knowledge 
            _waypointRepository.Add(waypoint);

            _historicoWaypointsRepository.Add(logWaypoint);

            return new CodResponse { Successo = true , Codigo = waypoint.Codigo};
        }

        public ResponseBase RoteirizarWaypoints(List<string> codigoWaypoint, string codigoRota)
        {
            _waypointRepository.AtualizarCodigoRota(codigoWaypoint, codigoRota);

            _historicoWaypointsRepository.AtualizarHistoricos(codigoWaypoint, SituacaoEntrega.EmAndamento);

            return new ResponseBase { Successo = true };    
        }

        public ResponseBase FinalizarEntrega(string codigoWaypoint)
        {
            _waypointRepository.FinalizarEntrega(codigoWaypoint);

            _historicoWaypointsRepository.AtualizarHistorico(codigoWaypoint, SituacaoEntrega.Finalizada);

            return new ResponseBase { Successo = true };  
        }

        public DashboardResponse ObterDashboard()
        {
            var contadores = _historicoWaypointsRepository.ObterDashboard();

            return new DashboardResponse
            {
                Successo = true,
                EmAndamento = contadores.EmAndamento,
                Entregues = contadores.Entregues,
                NaoEntregues = contadores.NaoEntregues,
                EntreguesHoje = contadores.EntreguesHoje
            };
        }
    }
}
