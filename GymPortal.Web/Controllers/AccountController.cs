using GymPortal.Infrastructure.Identity;
using GymPortal.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymPortal.Web.Controllers
{
    public class AccountController : Controller
    {

        /* =====================================================
                            IDENTITY-TJÄNSTER
        ===================================================== */

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        /* =====================================================
                             KONTOÖVERSIKT
        ===================================================== */

        [Authorize]
        public IActionResult AboutMe()
        {
            ViewBag.Email = User.Identity?.Name;

            return View();
        }


        /* =====================================================
                            REDIGERA PROFIL
        ===================================================== */

        // AI-stöd användes för strukturering av profiluppdateringen.
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("AboutMe");

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("AboutMe");
        }


        /* =====================================================
                               REGISTRERING
        ===================================================== */

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        // Delar av valideringsstrukturen togs fram med hjälp av AI.
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = "New",
                LastName = "Member"
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("AboutMe", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


        /* =====================================================
                                INLOGGNING
        ===================================================== */

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // AI användes som stöd vid felsökning av inloggningsflödet.
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                false,
                false);

            if (result.Succeeded)
                return RedirectToAction("AboutMe", "Account");

            ModelState.AddModelError("", "Invalid login attempt.");

            return View(model);
        }


        /* =====================================================
                                UTLOGGNING
        ===================================================== */

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        /* =====================================================
                              TA BORT KONTO
        ===================================================== */

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            await _signInManager.SignOutAsync();

            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index", "Home");
        }


        /* =====================================================
                                  LÖSENORD
        ===================================================== */

        public IActionResult SetPassword()
        {
            return View();
        }
    }
}