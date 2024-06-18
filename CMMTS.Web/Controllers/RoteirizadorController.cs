using CMMTS.Application.Messaging.Requests;
using CMMTS.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMMTS.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoteirizadorController : ControllerBase
    {
        private readonly ICentroDistribuicaoService _centroDistribuicaoService;
        private readonly IWaypointService _waypointService;
        private readonly IRotasService _rotasService;

        public RoteirizadorController(
            ICentroDistribuicaoService centroDistribuicaoService,
            IWaypointService waypointService,
            IRotasService rotasService) 
        {
            _centroDistribuicaoService = centroDistribuicaoService;
            _waypointService = waypointService;
            _rotasService = rotasService;
        }

        [HttpGet("BuscarCentrosDistribuicao")]
        public IActionResult BuscarCentrosDistribuicao()
        {
            try
            {
                var response = _centroDistribuicaoService.BuscarCentros();

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("AdicionarCentro")]
        public IActionResult AdicionarCentro(CadastrarCentroRequest centroDistribuicao)
        {
            try
            {
                var response = _centroDistribuicaoService.AdicionarCentro(centroDistribuicao);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("BuscarWayPoints")]
        public IActionResult BuscarWayPoints()
        {
            try
            {
                var response = _waypointService.BuscarWaypoints();

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("AdicionarWaypoint")]
        public IActionResult AdicionarWaypoint(CadastrarWaypointRequest cadastrarWaypoint)
        {
            try
            {
                var response = _waypointService.AdicionarWaypoint(cadastrarWaypoint);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("RoteirizarWaypoint")]
        public IActionResult RoteirizarWaypoints(RoteirizarWaypointsRequest roteirizarWaypoints)
        {
            try
            {
                var response = _waypointService.RoteirizarWaypoints(roteirizarWaypoints.CodigoWaypoint, roteirizarWaypoints.CodigoRota);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        [HttpPost("FinalizarEntrega")]
        public IActionResult FinalizarEntrega(string codigoWaypoint)
        {
            try
            {
                var response = _waypointService.FinalizarEntrega(codigoWaypoint);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeletarRota")]
        public IActionResult DeletarRota(string codigoRota)
        {
            try
            {
                var response = _rotasService.DeletarRota(codigoRota);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("BuscarRotas")]
        public IActionResult BuscarRotas(DateTime? data)
        {
            try
            {
                var response = _rotasService.BuscarRotas(data);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("AdicionarRota")]
        public IActionResult AdicionarRota(CadastrarRotaRequest cadastrarRota)
        {
            try
            {
                var response = _rotasService.AdicionarRota(cadastrarRota);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            try
            {
                var response = _waypointService.ObterDashboard();

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
