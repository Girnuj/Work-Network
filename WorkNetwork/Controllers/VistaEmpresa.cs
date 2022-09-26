namespace WorkNetwork.Controllers
{
    public class VistaEmpresa : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public VistaEmpresa(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: VistaEmpresa
        public ActionResult Index()
        {
            return View();
        }

        // GET: VistaEmpresa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VistaEmpresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VistaEmpresa/Create
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

        // GET: VistaEmpresa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VistaEmpresa/Edit/5
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

        // GET: VistaEmpresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VistaEmpresa/Delete/5
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
