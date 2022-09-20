using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkNetwork.Data;
using WorkNetwork.Models;

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


        //--------------------PARAMETROS DEL GUARDAR PERSONA ---------------------------


        public JsonResult GuardarPersona(int idPersona, string nombrePersona, string apellidoPersona,
            int numeroDocumento, DateTime fechaNacimiento, string mailUser, string domicilioPersona,
            int idLocalidad, int telefono1, int telefono2, string estadoCivil, string tituloAcademico,
            int cantidadHijos, string ImagenString, int SituacionLaboralid, int Generoid, int TipoDocumentoid, IFormFile adjunto)
        {
            if (adjunto.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    adjunto.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    var tipoDeArchivo = adjunto.ContentType;
                    string base64 = Convert.ToBase64String(fileBytes);
                }
            }
            bool resultado = true;

            var situacionLaboralEnum = SituacionLaboral.Desempleado;
            if (SituacionLaboralid == 1)
            {
                situacionLaboralEnum = SituacionLaboral.Empleado;
            }

            var generoEnum = Genero.Masculino;
            if (Generoid == 1)
            {
                generoEnum = Genero.Femenino;
            }
            else
            {
                generoEnum = Genero.Otro;
            }

            var tipoDocumentoEnum = TipoDocumento.dni;
            if (TipoDocumentoid == 1)
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
                LocalidadID = idLocalidad,
                SituacionLaboral = situacionLaboralEnum,
                CantidadHijos = cantidadHijos,
                Genero = generoEnum,
                Telefono1 = telefono1,
                Telefono2 = telefono2,
                EstadoCivil = estadoCivil,
                TituloAcademico = tituloAcademico,
                ImagenString = ImagenString


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
