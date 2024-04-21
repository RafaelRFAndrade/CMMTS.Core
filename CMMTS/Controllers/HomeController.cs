using CMMTS.Domain.Entities;
using CMMTS.Domain.Interfaces;
using CMMTS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CMMTS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public HomeController(ILogger<HomeController> logger, IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            //var resultado = _usuarioRepository.GetAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar2(Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
