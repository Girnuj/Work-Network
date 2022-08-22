using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkNetwork.Data;
using WorkNetwork.Models;

namespace WorkNetwork.Controllers
{
    [Authorize(Roles ="SuperUsuario")]
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
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


        public JsonResult GuardarPersona(int IdPersona, string NombrePersona, string ApellidoPersona,
            int NumeroDocumento, DateTime FechaNacimiento, string MailUser, string DomicilioPersona,
            int IdLocalidad, int Telefono1, int Telefono2, string EstadoCivil, string TituloAcademico,
            int CantidadHijos, string ImagenString, int SituacionLaboralid, int Generoid, int TipoDocumentoid)
        {
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
            return Json(resultado);
        }
    }

}
