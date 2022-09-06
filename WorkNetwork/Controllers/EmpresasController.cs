using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkNetwork.Data;
using WorkNetwork.Models;

namespace WorkNetwork.Controllers
{
    [Authorize(Roles = "Empresa")]
    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public EmpresasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
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

        //public void BuscarEmpresaActual(string usuarioActual, EmpresaUsuario empresaUsuarioActual)
        //{
        //    empresaUsuarioActual = _context.EmpresaUsuarios.Where(p => p.UsuarioID == usuarioActual).SingleOrDefault();
        //}

        //public JsonResult BuscarUsuario()
        //{
        //    var usuarioActual = _userManager.GetUserId(HttpContext.User);
        //    EmpresaUsuario empresaUsuarioActual = new EmpresaUsuario();
        //    BuscarEmpresaActual(usuarioActual, empresaUsuarioActual);
        //}

        public JsonResult TablaEmpresas()
        {
            var empresas = _context.Empresa.ToList();
            return Json(empresas);
        }

        public JsonResult GuardarEmpresa(int idEmpresa, string RazonSocial, int CUIT, string Email, int LocalidadID, int Telefono1, int Telefono2, int RubroID, int TipoEmpresaID)
        {
            var resultado = true;
            var tipoEmpresaEnum = TipoEmpresa.Unipersonal;
            if (TipoEmpresaID == 1)
            {
                tipoEmpresaEnum = TipoEmpresa.Sociedad;
            }

            var nuevaEmpresa = new Empresa
            {
                RazonSocial = RazonSocial,
                CUIT = CUIT,
                Email = Email,
                LocalidadID = LocalidadID,
                Telefono1 = Telefono1,
                Telefono2 = Telefono2,
                RubroID = RubroID,
                TipoEmpresa = tipoEmpresaEnum,
            };
            _context.Add(nuevaEmpresa);
            _context.SaveChanges();
            return Json(resultado);
        }
    

          public JsonResult BuscarEmpresa(int EmpresaID)
        {
            var empresa = _context.Empresa.FirstOrDefault(m => m.EmpresaID == EmpresaID);

            return Json(empresa);
        }

         public JsonResult EliminarEmpresa(int EmpresaID, int Elimina)
         {
            int resultado = 0;

            var empresa = _context.Empresa.Find(EmpresaID);
            if (empresa != null)
            {
                if (Elimina == 0)
                {
                    empresa.Eliminado = false;
                    _context.SaveChanges();
                }
                else
                {
                    empresa.Eliminado = true;
                    //NO PUEDE ELIMINAR EMPRESA SI TIENE RUBROS ACTIVOS
                    //var cantidadRubros = (from o in _context.Rubro where o.EmpresaID == EmpresaID && o.Eliminado == false select o).Count();
                    //if (cantidadRubros == 0)
                    //{
                    //    empresa.Eliminado = true;
                    //    _context.SaveChanges();
                    //}
                    //else
                    //{
                    //    resultado = 1;
                    //}
                }
                _context.SaveChanges();
            }

            return Json(resultado);


         }
               private bool RubroExists(int id)
               {
            return _context.Rubro.Any(e => e.RubroID == id);
               }

    }

}
