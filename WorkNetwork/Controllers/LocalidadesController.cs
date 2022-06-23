using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkNetwork.Data;

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
            return View(_context.Localidad.ToList());
        }

    }
}
