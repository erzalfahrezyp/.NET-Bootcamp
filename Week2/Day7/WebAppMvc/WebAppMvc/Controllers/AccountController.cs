using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAppMvc.Models;

namespace WebAppMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult GenerateRoles()
        {
            string[] roles = { "Admin", "Manager", "Member" };
            foreach(var role in roles)
            {
                var hasil = _roleManager.CreateAsync(new IdentityRole(role)).GetAwaiter().GetResult();
            }
            return View("Index");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterView usr)
        {
            if(ModelState.IsValid)
            {
                // validasi
                AppUser user = new AppUser
                {
                    // user
                    UserName = usr.Username,
                    FullName = usr.FullName
                };

                var result =  _userManager.CreateAsync(user, usr.Password).GetAwaiter().GetResult();
                if(result.Succeeded)
                {
                    // add role
                    var hasil2 = _userManager.AddToRoleAsync(user, "Member").GetAwaiter().GetResult();
                    if(hasil2.Succeeded)
                        return RedirectToAction("Index", "Home");
                }
            }
            return View(usr);
        }
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginView usr, string? returnUrl)
        {
            //if (ModelState.IsValid)
            //{
                var usrapp = _userManager.FindByNameAsync(usr.Username)
                    .GetAwaiter().GetResult();
                if (usrapp != null)
                {
                    // session clear
                    _signInManager.SignOutAsync().GetAwaiter().GetResult();
                    var hasil = _signInManager.PasswordSignInAsync(
                        usrapp, usr.Password, false, false).GetAwaiter().GetResult();
                    if (hasil.Succeeded)
                        return Redirect(returnUrl ?? "/home"); // ? = else, ?? = jika returnUrl tidak ada
                }
            //}
            return View(usr);
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
            return Redirect("/home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
