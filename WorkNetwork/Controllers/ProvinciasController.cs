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
            var paiss = _context.Pais.ToList();
            ViewBag.PaisID = new SelectList(paiss.OrderBy(e => e.NombrePais), "PaisID", "NombrePais");
            return View();
        }

        public JsonResult TablaProvincias()
        {
            var personas = _context.Provincia.ToList();
            return Json(personas);
        }
        public JsonResult CrearProvincia(int IdProvincia, string NombreProvincia, int PaisID)
        {
            bool resultado = true;
            var provincia = new Provincia
            {

                NombreProvincia = NombreProvincia,
                PaisID = PaisID

            };
            _context.Add(provincia);
            _context.SaveChanges();
            return Json(resultado);
        }
   
    }
}
