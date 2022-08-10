using Microsoft.AspNetCore.Mvc;
using WorkNetwork.Data;
using WorkNetwork.Models;

namespace WorkNetwork.Controllers
{
    public class PaisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaisesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Pais.ToList());
        }
        public JsonResult TablaPaises()
        {
            var paises = _context.Pais.ToList();
            return Json(paises);
        }
        public JsonResult CrearPais(string NombrePais,int PaisID)
        {
            int resultado = 0;
            //Si es 0 es correcto
            //Si es 1 descripcion vacia
            //Si es 2 campo existente
            if (!string.IsNullOrEmpty(NombrePais))
            {
                NombrePais = NombrePais.ToUpper(); 
                if(PaisID == 0)
                {
                    if(_context.Pais.Any(e=> e.NombrePais == NombrePais))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //Creo el pais
                        var pais = new Pais
                        {
                            NombrePais = NombrePais,
                        };
                        _context.Add(pais);
                        _context.SaveChanges();
                    }

                }
                else
                {
                    if(_context.Pais.Any(e => e.NombrePais == NombrePais && e.PaisID != PaisID))
                    {
                        resultado=2;
                    }
                    else
                    {
                        var pais = _context.Pais.Single(e=>e.PaisID == PaisID);
                        pais.NombrePais=NombrePais;
                        _context.SaveChanges();
                    }
                }

            }
            return Json(resultado);

        }

    }
}
