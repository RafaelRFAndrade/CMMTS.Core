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

        [HttpPost]
        public IActionResult CadastrarUsuarios()
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

        [HttpPost("Login")]
        public IActionResult LogarUsuarios(string nome, string senha)
        {
            try
            {
                var login = _usuarioService.LogarUsuario(nome, senha);

                return Ok(login);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
