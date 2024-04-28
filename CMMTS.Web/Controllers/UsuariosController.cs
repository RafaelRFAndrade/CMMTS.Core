using CMMTS.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMMTS.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult BuscarUsuarios()
        {
            try
            {
                var usuarios = _usuarioService.BuscarUsuarios();

                return Ok(usuarios);
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
