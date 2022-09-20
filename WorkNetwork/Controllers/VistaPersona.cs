namespace WorkNetwork.Controllers
{
    public class VistaPersona : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public VistaPersona(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: VistaPersona
        public ActionResult Index()
        {
            return View();
        }

        // GET: VistaPersona/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VistaPersona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VistaPersona/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VistaPersona/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VistaPersona/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VistaPersona/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VistaPersona/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
