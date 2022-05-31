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
        public JsonResult CrearPersona(int IdPersona, string NombrePersona, string ApellidoPersona)
        {
            bool resultado = false;
            var persona = new Persona
            {
                nombrePersona = NombrePersona,
                apellidoPersona = ApellidoPersona, 
            };
            _context.Add(persona);
            _context.SaveChanges();
            return Json(resultado);
        }
    }
}
