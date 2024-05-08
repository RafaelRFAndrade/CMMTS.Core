using CMMTS.Application.Services;
using CMMTS.Application.Messaging.Requests;
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

        [HttpPost("Cadastrar")]
        public IActionResult CadastrarUsuarios(CadastrarUsuarioRequest request)
         {
            try
            {
                var response = _usuarioService.CadastrarUsuario(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult LogarUsuarios(UsuarioLoginRequest request)
        {
            try
            {
                var login = _usuarioService.LogarUsuario(request);

                return Ok(login);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
