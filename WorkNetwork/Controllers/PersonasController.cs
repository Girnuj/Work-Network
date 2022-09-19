namespace WorkNetwork.Controllers
{
    [Authorize(Roles ="Usuario, SuperUsuario")]
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public PersonasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
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

            // BUSCO EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            
            //EN BASE AL USUARIO BUSCO EN LA TABLA PARA VER SI ESTA RELACIONADO A ALGUAN PERSONA. 
            var UsuarioRelacionado= _context.PersonaUsuarios.Where(p => p.UsuarioID == usuarioActual).Count();
            if(UsuarioRelacionado == 0 ){
                return View();
            }else{
                return RedirectToAction("Index","Home");
            }
        }

        public JsonResult TablaPersonas()
        {
            var personas = _context.Persona.ToList();
            return Json(personas);
        }
        //public JsonResult CrearPersona(int IdPersona, string NombrePersona, string ApellidoPersona)
        //{
        //    bool resultado = false;
        //    var persona = new Persona
        //    {
        //        NombrePersona = NombrePersona,
        //        ApellidoPersona = ApellidoPersona, 
        //    };
        //    _context.Add(persona);
        //    _context.SaveChanges();
        //    return Json(resultado);
        //}


        public JsonResult GuardarPersona(int IdPersona, string NombrePersona, string ApellidoPersona,
            int NumeroDocumento, DateTime FechaNacimiento, string MailUser, string DomicilioPersona,
            int IdLocalidad, int Telefono1, int Telefono2, string EstadoCivil, string TituloAcademico,
            int CantidadHijos, string ImagenString, int SituacionLaboralid, int Generoid, int TipoDocumentoid)
        {
            bool resultado = true;

            var situacionLaboralEnum = SituacionLaboral.Desempleado;
            if (SituacionLaboralid is 1)
            {
                situacionLaboralEnum = SituacionLaboral.Empleado;
            }

            var generoEnum = Genero.Masculino;

            if (Generoid is 1)
            {
                generoEnum = Genero.Femenino;
            }
            else
            {
                generoEnum = Genero.Otro;
            }

            var tipoDocumentoEnum = TipoDocumento.dni;
            if (TipoDocumentoid is 1)
            {
                tipoDocumentoEnum = TipoDocumento.LE;
            }

            var persona = new Persona
            {
                NombrePersona = NombrePersona,
                ApellidoPersona = ApellidoPersona,
                TipoDocumento = tipoDocumentoEnum,
                NumeroDocumento = NumeroDocumento,
                FechaNacimiento = FechaNacimiento,
                CorreoElectronico = MailUser,
                DomicilioPersona = DomicilioPersona,
                LocalidadID = IdLocalidad,
                SituacionLaboral = situacionLaboralEnum,
                CantidadHijos = CantidadHijos,
                Genero = generoEnum,
                Telefono1 = Telefono1,
                Telefono2 = Telefono2,
                EstadoCivil = EstadoCivil,
                TituloAcademico = TituloAcademico,

                ImagenString = ImagenString


            };
            resultado = false;
            _context.Add(persona);
            _context.SaveChanges();

            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            var nuevaPersonaUsuario = new PersonaUsuario
            {
                UsuarioID= usuarioActual,
                PersonaID= persona.PersonaID
            };
            _context.Add(nuevaPersonaUsuario);
            _context.SaveChanges();

            return Json(resultado);
        }


        //        public JsonResult EliminarPersona(int PersonaID, int Elimina)
         //{
           // int resultado = 0;

            //var pais = _context.Paises.Find(PaisID);
            //if (pais != null)
            //{
              //  if (Elimina == 0)
                //{
                  //  pais.Eliminado = false;
                    //_context.SaveChanges();
                //}
                //else
                //{
                    //NO PUEDE ELIMINAR EMPRESA SI TIENE RUBROS ACTIVOS
                  //  var cantidadProvincias = (from o in _context.Provincias where o.PaisID == PaisID && o.Eliminado == false select o).Count();
                    //if (cantidadProvincias == 0)
                    //{
                      //  pais.Eliminado = true;
                        //_context.SaveChanges();
                    //}
                    //else
                    //{
                      //  resultado = 1;
                    //}
                //}                              
           // }

            //return Json(resultado);
    }

}
