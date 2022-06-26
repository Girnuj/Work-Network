using Microsoft.AspNetCore.Mvc;
using WorkNetwork.Data;

namespace WorkNetwork.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult TablaEmpresas()
        {
            var empresas = _context.Empresa.ToList();
            return Json(empresas);
        }
    }
}
