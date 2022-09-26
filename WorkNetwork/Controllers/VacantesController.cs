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

        public JsonResult GuardarVacante(int idVacante, int idEmpresa, string NombreEmpresa,
               string DescripcionVacante, string ExperienciaRequerida, int idLocalidad,
               DateTime FechaDeFinalizacion, string Idiomas, string ImagenString,
               string Estado, int DisponibilidadHorariaid, int TipoModalidadid)
        {
            bool resultado = true;
            var disponibilidadHorariaEnum = DisponibilidadHoraria.fulltime;
           
            if (DisponibilidadHorariaid is 1) disponibilidadHorariaEnum = DisponibilidadHoraria.partime;

            var tipoModalidadEnum = tipoModalidad.presencial;

            if (TipoModalidadid is 1) tipoModalidadEnum = tipoModalidad.semipresencial;
  
            else 
              tipoModalidadEnum = tipoModalidad.remoto;
            

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


        public JsonResult BuscarVacante(int VacanteID)
        {
            var vacante = _context.Vacante.FirstOrDefault(m => m.VacanteID == VacanteID);

            return Json(vacante);
        }

        public JsonResult EliminarVacante(int VacanteID, int Elimina)
        {
            int resultado = 0;

            var vacante = _context.Vacante.Find(VacanteID);
            if (vacante is not null)
            {
                if (Elimina is 0)
                {
                    vacante.Eliminado = false;
                    _context.SaveChanges();
                }
                else
                {
                    //NO PUEDE ELIMINAR EMPRESA SI TIENE RUBROS ACTIVOS
                    // var cantidadRubros = (from o in _context.Rubros where o.EmpresaID == EmpresaID && o.Eliminado == false select o).Count();
                    //if (cantidadRubros == 0)
                    //{
                    //Vacante.Eliminado = true;
                    //_context.SaveChanges();
                    //}
                    //else
                    //{
                    //   resultado = 1;
                    //}
                }
            }

            return Json(resultado);

        }
        private bool VacanteExists(int id)
        {
            return _context.Vacante.Any(e => e.VacanteID == id);
        }
    }
}

