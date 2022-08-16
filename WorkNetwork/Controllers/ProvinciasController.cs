using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public ProvinciasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            

            var paiss = _context.Pais.ToList();
            paiss.Add(new Pais { PaisID = 0, NombrePais = "[SELECCIONE UN PAIS]" });
            ViewBag.PaisID = new SelectList(paiss.OrderBy(e => e.NombrePais), "PaisID", "NombrePais");
            return View(await _context.Provincia.ToListAsync());
        }

        public JsonResult ComboProvincia(int id)
        {
            var provincias = (from p in _context.Provincia where p.PaisID == id select p).ToList();
            return Json(new SelectList(provincias, "ProvinciaID", "NombreProvincia"));
        }

        public JsonResult TablaProvincias()
        {
            var provincias = _context.Provincia.ToList();
            return Json(provincias);
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
