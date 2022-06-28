using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkNetwork.Data;
using WorkNetwork.Models;

namespace WorkNetwork.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var paises = _context.Pais.ToList();
            paises.Add(new Pais { PaisID = 0, NombrePais="[SELECCIONE UN PAIS]" });
            ViewBag.PaisID = new SelectList(paises.OrderBy(e => e.NombrePais), "PaisID", "NombrePais");

            var provincias = _context.Provincia.ToList();
            provincias.Add(new Provincia{ ProvinciaID= 0, NombreProvincia="[SELECCIONE UN PAIS]" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(x => x.NombreProvincia), "ProvinciaID", "NombreProvincia");

            var localidad = _context.Localidad.ToList();
            localidad.Add(new Localidad{ LocalidadID= 0, NombreLocalidad="[SELECCIONE UN PAIS]" });
            ViewBag.LocalidadID = new SelectList(localidad.OrderBy(x => x.NombreLocalidad), "LocalidadID", "NombreLocalidad");

            var rubros = _context.Rubro.ToList();
            rubros.Add(new Rubro { RubroID = 0, NombreRubro = "[SELECCIONE UN RUBRO]" });
            ViewBag.RubroID = new SelectList(rubros.OrderBy(x => x.NombreRubro), "RubroID", "NombreRubro");

            return View();
        }

        public JsonResult TablaEmpresas()
        {
            var empresas = _context.Empresa.ToList();
            return Json(empresas);
        }
    }
}
