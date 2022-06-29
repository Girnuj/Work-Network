using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkNetwork.Data;
using WorkNetwork.Models;

namespace WorkNetwork.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Persona.ToListAsync());
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
            int NumeroDocumento, DateTime FechaNacimiento , string CorreoElectronico, string DomicilioPersona,
            int IdLocalidad,int Telefono1, int Telefono2, string EstadoCivil, string TituloAcademico, 
            int CantidadHijos, string ImagenString, int SituacionLaboralid, int Generoid, int TipoDocumentoid)
        {
            bool resultado = true;
            var situacionLaboralEnum = SituacionLaboral.Desempleado;
            if (SituacionLaboralid == 1)
            {
                situacionLaboralEnum = SituacionLaboral.Empleado;
            }

            var generoEnum = Genero.Masculino;
            if(Generoid == 1)
            {
                generoEnum = Genero.Femenino;
            }
            else
            {
                //generoEnum = Genero.Otro;
            }

            var tipoDocumentoEnum = TipoDocumento.dni;
            if(TipoDocumentoid == 1)
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
                CorreoElectronico = CorreoElectronico,
                DomicilioPersona = DomicilioPersona,
                
                SituacionLaboral = situacionLaboralEnum,
                Genero = generoEnum,
                Telefono1 = Telefono1,
                Telefono2 = Telefono2,
                EstadoCivil = EstadoCivil,
                TituloAcademico = TituloAcademico,
                CantidadHijos = CantidadHijos,
                ImagenString = ImagenString
              

            };
            _context.Add(persona);
            _context.SaveChanges();
            return Json(resultado);
        }
    }

}
