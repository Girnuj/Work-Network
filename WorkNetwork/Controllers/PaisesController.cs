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
            return View();
        }

        public JsonResult CrearPais(string Nombre)
        {
            var pais = new Pais
            {
                nombrePais = Nombre
            };
            _context.Add(pais);
            _context.SaveChanges();
            return Json(pais);  
        }
    }
}
