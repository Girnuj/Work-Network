namespace WorkNetwork.Controllers
{
    [Authorize(Roles = "Empresa, SuperUsuario")]
    public class VacantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public VacantesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public JsonResult GuardarVacante(int vacanteID,string tituloVacante,
               string descripcionVacante, string experienciaRequerida, int LocalidadID,int RubroID,
               DateTime fechaFinalizacion, string idiomaVacante, string ImagenString,
               string Estado, int disponibilidadHoraria, int modalidadVacante)
        {
            bool resultado = true;
            var disponibilidadHorariaEnum = DisponibilidadHoraria.fulltime;
           
            if (disponibilidadHoraria is 1) disponibilidadHorariaEnum = DisponibilidadHoraria.partime;

            var tipoModalidadEnum = tipoModalidad.presencial;

            if (modalidadVacante is 1) tipoModalidadEnum = tipoModalidad.semipresencial;
  
            else 
              tipoModalidadEnum = tipoModalidad.remoto;
            

            var nuevaVacante = new Vacante
            {
                Nombre = tituloVacante,
                Descripcion = descripcionVacante,
                ExperienciaRequerida = experienciaRequerida,
                LocalidadID = LocalidadID,
                FechaDeFinalizacion = fechaFinalizacion,
                Idiomas = idiomaVacante,
                RubroID = RubroID,
                Estado = Estado,
                Eliminado = false,
                DisponibilidadHoraria = disponibilidadHorariaEnum,
                tipoModalidad = tipoModalidadEnum,

            };
            _context.Add(nuevaVacante);
            _context.SaveChanges();

            //BUSCO EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //EN BASE A ESE ID BUSCAMOS EN LA TABLA DE RELACION USUARRIO-EMPRESA QUE REGISTRO TIENE
            var empresaUsuario = _context.EmpresaUsuarios.Where(u => u.UsuarioID == usuarioActual).FirstOrDefault();
            //EN BASE A ESA VARIABLE RECURRIMOS AL ID DE LA EMPRESA ACTUAL PARA RELACIONARLA CON LA VACANTE 
            var empresaID = _context.EmpresaUsuarios.Where(u => u.EmpresaID == empresaUsuario.EmpresaID).Select(r=>r.EmpresaID).FirstOrDefault();
            var nuevaEmpresaVacante = new VacanteEmpresa
            {
                VacanteID = nuevaVacante.VacanteID,
                EmpresaID = empresaID
            };
            _context.Add(nuevaEmpresaVacante);
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

