using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkNetwork.Data;
using WorkNetwork.Models;

namespace WorkNetwork.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvinciasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var paises = _context.Pais.ToList();
            ViewBag.idPais = new SelectList(paises, "idPais", "nombrePais");
            return View();
        }
        public JsonResult CrearProvincia(string nombreProvincia, int idPais)
        {
            
            var provincia = new Provincia
            {
                nombreProvincia = nombreProvincia,
            };
            _context.Add(provincia);
            _context.SaveChanges();
            return Json(provincia);
        }
    }
}
