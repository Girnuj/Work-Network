using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkNetwork.Data;
using WorkNetwork.Models;


namespace WorkNetwork.Controllers
{
    [Authorize(Roles = "SuperUsuario")]
    public class VacantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VacantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var paises = _context.Pais.ToList();
            paises.Add(new Pais { PaisID = 0, NombrePais = "[SELECCIONE UN PAIS]" });
            ViewBag.PaisID = new SelectList(paises.OrderBy(e => e.NombrePais), "PaisID", "NombrePais");

            var provincias = _context.Provincia.ToList();
            provincias.Add(new Provincia { ProvinciaID = 0, NombreProvincia = "[SELECCIONE UN PAIS]" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(x => x.NombreProvincia), "ProvinciaID", "NombreProvincia");

            var localidad = _context.Localidad.ToList();
            localidad.Add(new Localidad { LocalidadID = 0, NombreLocalidad = "[SELECCIONE UN PAIS]" });
            ViewBag.LocalidadID = new SelectList(localidad.OrderBy(x => x.NombreLocalidad), "LocalidadID", "NombreLocalidad");

            var rubros = _context.Rubro.ToList();
            rubros.Add(new Rubro { RubroID = 0, NombreRubro = "[SELECCIONE UN RUBRO]" });
            ViewBag.RubroID = new SelectList(rubros.OrderBy(x => x.NombreRubro), "RubroID", "NombreRubro");


            return View();
        }



        public JsonResult TablaVacasntes()
        {
            var vacantes = _context.Vacante.ToList();
            return Json(vacantes);
        }

        public JsonResult GuardarVacante(int idVacante,int idEmpresa, string NombreEmpresa,
               string DescripcionVacante, string ExperienciaRequerida, int idLocalidad,
               DateTime FechaDeFinalizacion, string Idiomas, string ImagenString,
               string Estado, int DisponibilidadHorariaid, int TipoModalidadid)
        {
            bool resultado = true;
            var disponibilidadHorariaEnum = DisponibilidadHoraria.fulltime;
            if (DisponibilidadHorariaid == 1)
            {
                disponibilidadHorariaEnum = DisponibilidadHoraria.partime;
            }

          
            var tipoModalidadEnum = tipoModalidad.presencial;
            if (TipoModalidadid == 1)
            {
                tipoModalidadEnum = tipoModalidad.semipresencial;
            }
            else
            {
                tipoModalidadEnum = tipoModalidad.remoto;
            }

            var nuevaVacante = new Vacante
            {
                Nombre = NombreEmpresa,
                Descripcion = DescripcionVacante,
                ExperienciaRequerida = ExperienciaRequerida,
                LocalidadID = idLocalidad,
                FechaDeFinalizacion = FechaDeFinalizacion,
                Idiomas = Idiomas,
                ImagenString = ImagenString,
                Estado = Estado,
                DisponibilidadHoraria = disponibilidadHorariaEnum,
                tipoModalidad = tipoModalidadEnum,

            };
            _context.Add(nuevaVacante);
            _context.SaveChanges();
            return Json(resultado);
        }
    }
}

