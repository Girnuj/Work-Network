using Microsoft.AspNetCore.Mvc;
using WorkNetwork.Data;
using WorkNetwork.Models;

namespace WorkNetwork.Controllers
{
    public class PaisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaisesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Pais.ToList());
        }
        public JsonResult TablaPaises()
        {
            var paises = _context.Pais.ToList();
            return Json(paises);
        }
        public JsonResult CrearPais(string NombrePais)
        {
            bool resultado = false;
            var pais = new Pais
            {
                NombrePais = NombrePais,
            };
            _context.Add(pais);
            _context.SaveChanges();
            return Json(resultado);

        }

    }
}
