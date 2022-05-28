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

        // GET: Personas
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Persona != null ? 
        //                  View(await _context.Persona.ToListAsync()) :
        //                  Problem("Entity set 'ApplicationDbContext.Persona'  is null.");
        //}

        // GET: Personas/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Persona == null)
        //    {
        //        return NotFound();
        //    }

        //    var persona = await _context.Persona
        //        .FirstOrDefaultAsync(m => m.idPersona == id);
        //    if (persona == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(persona);
        //}

        // GET: Personas/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("idPersona,nombrePersona,apellidoPersona,numeroDocumento,fechaNacimiento,correoElectronico,domicilioPersona,idLocalidad,Genero,telefono1,telefono2,estadoCivil,tituloAcademico,idSubRubro,cantidadHijos")] Persona persona)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(persona);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(persona);
        //}

        // GET: Personas/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Persona == null)
        //    {
        //        return NotFound();
        //    }

        //    var persona = await _context.Persona.FindAsync(id);
        //    if (persona == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(persona);
        //}

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("idPersona,nombrePersona,apellidoPersona,numeroDocumento,fechaNacimiento,correoElectronico,domicilioPersona,idLocalidad,Genero,telefono1,telefono2,estadoCivil,tituloAcademico,idSubRubro,cantidadHijos")] Persona persona)
        //{
        //    if (id != persona.idPersona)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(persona);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PersonaExists(persona.idPersona))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(persona);
        //}

        // GET: Personas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Persona == null)
        //    {
        //        return NotFound();
        //    }

        //    var persona = await _context.Persona
        //        .FirstOrDefaultAsync(m => m.idPersona == id);
        //    if (persona == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(persona);
        //}

        // POST: Personas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Persona == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Persona'  is null.");
        //    }
        //    var persona = await _context.Persona.FindAsync(id);
        //    if (persona != null)
        //    {
        //        _context.Persona.Remove(persona);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PersonaExists(int id)
        //{
        //  return (_context.Persona?.Any(e => e.idPersona == id)).GetValueOrDefault();
        //}
    }
}
