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
        //Para la creacion del usuario
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        public GestionDeUsuarios(ApplicationDbContext context, SignInManager<IdentityUser> singInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,IUserStore<IdentityUser> userStore)
        {
            _context = context;
            _singInManager = singInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
        }

        public async Task<JsonResult> Ingresar(string email, string password)
        {
            bool logueado = false;

            var result = await _singInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                logueado = true;
            }

            return Json(logueado);
        }
        public async Task<JsonResult> Registrar(string email, string password) {
            bool registrado=false;
            var user = CreateUser();
            await _userStore.SetUserNameAsync(user, email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                await _singInManager.SignInAsync(user, isPersistent: false);
                registrado = true;
            }

            return Json(registrado);
        }
        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
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
