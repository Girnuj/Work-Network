﻿namespace WorkNetwork.Controllers
{
    [Authorize]
    public class LocalidadesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public LocalidadesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            //Empresa actual
            var paises = _context.Pais.ToList();
            paises.Add(new Pais { PaisID = 0, NombrePais = "[SELECCIONE UN PAIS]" });
            ViewBag.PaisID = new SelectList(paises.OrderBy(e => e.NombrePais), "PaisID", "NombrePais");

            List<Provincia> provincias = new List<Provincia>();
            provincias.Add(new Provincia { ProvinciaID = 0, NombreProvincia = "[SELECCIONE UN PAIS]" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(x => x.NombreProvincia), "ProvinciaID", "NombreProvincia");
            return View(_context.Localidad.ToList());
        }
        // public void BuscarEmpresaActual(string usuarioActual, EmpresaUsuario empresaUsuarioActual)
        // {

        //     empresaUsuarioActual = _context.EmpresaUsuarios.Where(p => p.UsuarioID == usuarioActual).SingleOrDefault();
        // }
        public JsonResult TablaLocalidades()
        {
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
            // BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);

            var localidades = _context.Localidad.ToList();
            return Json(localidades);

        }
        public JsonResult ComboLocalidades(int id)
        {
            var localidades = (from p in _context.Localidad where p.ProvinciaID == id select p).ToList();
            return Json(new SelectList(localidades, "LocalidadID", "NombreLocalidad"));
        }
        public JsonResult GuardarLocalidad(int IdLocalidad, string NombreLocalidad, int CP, int ProvinciaID)
        {
            int resultado = 0;
            //Si es 0 es correcto
            //Si es 1 descripcion vacia
            //Si es 2 campo existente
            if (!string.IsNullOrEmpty(NombreLocalidad))
            {
                NombreLocalidad = NombreLocalidad.ToUpper();
                if (IdLocalidad is 0)
                {
                    if (_context.Localidad.Any(e => e.NombreLocalidad == NombreLocalidad && e.ProvinciaID == ProvinciaID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        var localidad = new Localidad
                        {
                            NombreLocalidad = NombreLocalidad,
                            CP = CP,
                            ProvinciaID = ProvinciaID,

                        };
                        _context.Add(localidad);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (_context.Localidad.Any(e => e.NombreLocalidad == NombreLocalidad && e.ProvinciaID != ProvinciaID))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        var localidad = _context.Localidad.Single(e => e.LocalidadID == IdLocalidad);
                        localidad.NombreLocalidad = NombreLocalidad;
                        localidad.CP = CP;
                        localidad.ProvinciaID = ProvinciaID;
                        _context.SaveChanges();
                    }
                }
            }
            return Json(resultado);
        }

        public JsonResult BuscarLocalidad(int LocalidadID)
        {
            var localidad = _context.Localidad.FirstOrDefault(m => m.LocalidadID == LocalidadID);

            return Json(localidad);
        }

        public JsonResult EliminarLocalidad(int LocalidadID, int Elimina)
        {
            int resultado = 0;

            var localidad = _context.Localidad.Find(LocalidadID);
            if (localidad is not null)
            {
                if (Elimina is 0)
                {
                    localidad.Eliminado = false;
                    _context.SaveChanges();
                }
                else
                {
                    //NO PUEDE ELIMINAR EMPRESA SI TIENE RUBROS ACTIVOS
                    // var cantidadRubros = (from o in _context.Rubros where o.EmpresaID == EmpresaID && o.Eliminado == false select o).Count();
                    //if (cantidadRubros == 0)
                    //{
                    localidad.Eliminado = true;
                    _context.SaveChanges();
                    //}
                    //else
                    //{
                    //   resultado = 1;
                    //}
                }
            }

            return Json(resultado);



        }
    }
            //   private bool LocalidadExists(int id)
            //   {
            //return _context.Localidad.Any(e => e.VacanteID == id);
            //   }
}
