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
            // BUSCO EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            
            var rolUsuario = _context.UserRoles.Where(u => u.UserId == usuarioActual).FirstOrDefault();
            //EN BASE A ESE ID BUSCAMOS EN LA TABLA DE RELACION USUARRIO-ROL QUE REGISTRO TIENE
            var rolNombre = _context.Roles.Where(u => u.Id == rolUsuario.RoleId).Select(r=>r.Name).FirstOrDefault();
            //EN BASE AL USUARIO BUSCO EN LA TABLA PARA VER SI ESTA RELACIONADO A ALGUAN PERSONA. 
            if (rolNombre is "Usuario"){

                var personaUsuario = (from p in _context.PersonaUsuarios where p.UsuarioID == usuarioActual select p).Count();
                if(personaUsuario == 0){
                     return RedirectToAction("NewPerson","Personas");
                }
            }
            return View();
        }

        public IActionResult PerfilUser()
        {
            return View();
        }

        public IActionResult NewPerson()
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
            
            return View();
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


        //--------------------PARAMETROS DEL GUARDAR PERSONA ---------------------------


        public JsonResult GuardarPersona(int idPersona, string nombrePersona, string apellidoPersona, int tipoDocumentoid, int numeroDocumento, int Generoid, DateTime fechaNacimiento,string mailUser,string domicilioPersona, int numeroDomicilio, int SituacionLaboralid, int LocalidadID, int telefono1, int telefono2, string estadoCivil, int cantidadHijos, string tituloAcademico, IFormFile adjunto)
        {
            byte[] img = null;
            string tipoImg = null; 
            string domicilioCompleto = domicilioPersona + numeroDomicilio;
            if (adjunto!= null){
            if (adjunto.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    adjunto.CopyTo(ms);
                    img = ms.ToArray();
                    tipoImg = adjunto.ContentType;
                }
            }
        }
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
             if(Generoid is 2)
             {
                 generoEnum = Genero.Otro;
             }

             var tipoDocumentoEnum = TipoDocumento.dni;
             if (tipoDocumentoid is 1)
             {
                 tipoDocumentoEnum = TipoDocumento.LE;
             }

            var persona = new Persona
            {
                NombrePersona = nombrePersona,
                 ApellidoPersona = apellidoPersona,
                 TipoDocumento = tipoDocumentoEnum,
                 NumeroDocumento = numeroDocumento,
                 FechaNacimiento = fechaNacimiento,
                 CorreoElectronico = mailUser,
                 DomicilioPersona = domicilioPersona,
                 LocalidadID = LocalidadID,
                 SituacionLaboral = situacionLaboralEnum,
                 CantidadHijos = cantidadHijos,
                 Genero = generoEnum,
                 Telefono1 = telefono1,
                 Telefono2 = telefono2,
                 EstadoCivil = estadoCivil,
                 TituloAcademico = tituloAcademico,
                 ImagenString = tipoImg,
                 Imagen = img
            };
            resultado = false;
            _context.Add(persona);
            _context.SaveChanges();

            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            var nuevaPersonaUsuario = new PersonaUsuario
            {
                UsuarioID= usuarioActual,
                PersonaID = persona.PersonaID
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
