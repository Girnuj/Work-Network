﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkNetwork.Data;
using WorkNetwork.Models;

namespace WorkNetwork.Controllers
{
    public class LocalidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalidadesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var paises = _context.Pais.ToList();
            paises.Add(new Pais { PaisID = 0, NombrePais = "[SELECCIONE UN PAIS]" });
            ViewBag.PaisID = new SelectList(paises.OrderBy(e => e.NombrePais), "PaisID", "NombrePais");

            List<Provincia> provincias = new List<Provincia>();
            provincias.Add(new Provincia { ProvinciaID = 0, NombreProvincia = "[SELECCIONE UN PAIS]" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(x => x.NombreProvincia), "ProvinciaID", "NombreProvincia");
            return View(_context.Localidad.ToList());
        }
        public JsonResult TablaLocalidades()
        {
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
                if (IdLocalidad == 0)
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
                }else{
                    if (_context.Localidad.Any(e=>e.NombreLocalidad== NombreLocalidad && e.ProvinciaID != ProvinciaID)){
                        resultado = 2;    
                    }else{
                        var localidad = _context.Localidad.Single(e => e.LocalidadID== IdLocalidad);
                            localidad.NombreLocalidad= NombreLocalidad;
                            localidad.CP = CP ;
                            localidad.ProvinciaID = ProvinciaID; 
                            _context.SaveChanges();
                    }
                }
            }
            return Json(resultado);
        }

    }
}
