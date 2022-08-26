using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkNetwork.Data;

namespace WorkNetwork.Controllers
{
    public class GestionDeUsuarios : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _singInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GestionDeUsuarios(ApplicationDbContext context, SignInManager<IdentityUser> singInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _singInManager = singInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        public JsonResult BuscarUsuarios()
        {
            var usersApp = _context.Users.ToList();
            return Json(usersApp);
        }
        
        public JsonResult BuscarRoles()
        {
            var rolesApp = _context.Roles.ToList();
            return Json(rolesApp);
        }
        public async Task<JsonResult> CrearRol(string name)
        {
            bool registro = false;
            if (!string.IsNullOrEmpty(name)) 
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    registro = true;
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Json(registro);  
        }
    }
}
