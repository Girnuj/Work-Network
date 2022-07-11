﻿using Microsoft.AspNetCore.Mvc;
using WorkNetwork.Data;
using WorkNetwork.Models;

namespace WorkNetwork.Controllers
{
    public class RubrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RubrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Rubro.ToList());
        }
        public JsonResult TablaRubros()
        {
            var rubros = _context.Rubro.ToList();
            return Json(rubros);
        }

        public JsonResult GuardarRubro(int idRubro, string NombreRubro)
        {
            int resultado = 0;
            //Si es 0 es correcto
            //Si es 1 descripcion vacia
            //Si es 2 campo existente
            if (!string.IsNullOrEmpty(NombreRubro))
            {
                NombreRubro = NombreRubro.ToUpper();
                if (idRubro == 0)
                {
                    if (_context.Rubro.Any(e => e.NombreRubro == NombreRubro))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //Aca va el crear
                        var rubroCrear = new Rubro
                        {
                            NombreRubro = NombreRubro
                        };
                        _context.Add(rubroCrear);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (_context.Rubro.Any(e => e.NombreRubro == NombreRubro && e.RubroID != idRubro))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //Aca va el editar
                        var rubro = _context.Rubro.Single(p => p.RubroID == idRubro);
                        rubro.NombreRubro = NombreRubro;
                        _context.SaveChanges();
                    }
                }

            }

            return Json(resultado);
        }
    }
}
