using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkNetwork.Data;
using WorkNetwork.Models;

namespace WorkNetwork.Controllers
{
    public class LocalidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalidadesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var paises = _context.Pais.ToList();
            paises.Add(new Pais { PaisID = 0, NombrePais="[SELECCIONE UN PAIS]" });
            ViewBag.PaisID = new SelectList(paises.OrderBy(e => e.NombrePais), "PaisID", "NombrePais");

            List<Provincia> provincias= new List<Provincia>();
            provincias.Add(new Provincia{ ProvinciaID= 0, NombreProvincia="[SELECCIONE UN PAIS" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(x => x.NombreProvincia), "ProvinciaID", "NombreProvincia");
            return View(_context.Localidad.ToList());
        }
        public JsonResult TablaLocalidades()
        {
            var localidades = _context.Localidad.ToList();
            return Json(localidades);
        }

        public JsonResult GuardarLocalidad(int IdLocalidad, string NombreLocalidad,int CP, int ProvinciaID)
        {
            bool resultado = true;
            var localidad = new Localidad
            {
                NombreLocalidad = NombreLocalidad,
                CP = CP,
                ProvinciaID = ProvinciaID,

            };
            _context.Add(localidad);
            _context.SaveChanges();
            return Json(resultado);
        }

    }
}
