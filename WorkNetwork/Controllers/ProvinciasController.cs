using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Provincia.ToListAsync());
        }

        public JsonResult TablaProvincias()
        {
            var personas = _context.Provincia.ToList();
            return Json(personas);
        }
        public JsonResult CrearProvincia(int IdProvincia, string NombreProvincia)
        {
            bool resultado = false;
            var provincia = new Provincia
            {
                NombreProvincia = NombreProvincia,
               
            };
            _context.Add(provincia);
            _context.SaveChanges();
            return Json(resultado);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
