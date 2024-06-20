using CMMTS.Application.Services;
using CMMTS.Application.Messaging.Requests;
using Microsoft.AspNetCore.Mvc;
using CMMTS.Domain.Entities;

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
        public IActionResult AtualizarUsuario(UsuarioLoginRequest request)
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

        [HttpPut("Usuario")]
        public IActionResult LogarUsuarios(Usuarios usuario)
        {
            try
            {
                var response = _usuarioService.AtualizarUsuario(usuario);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
