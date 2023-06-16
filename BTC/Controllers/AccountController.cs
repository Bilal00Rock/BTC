using BE;
using BTC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BTC.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> signInManager;
        public AccountController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Login()
        {


            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(RegisterModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربری با این نام کاربری پیدا نشد");
                return View(model);

            }

            var singInResult = await signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (!singInResult.Succeeded)
            {
                ModelState.AddModelError("", "نام کاربری یا رمز عبود اشتباه میباشد");
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Register()
        {
            

            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                ModelState.AddModelError("", "این نام کاربری در سیستم موجود میباشد");
                return View(model);

            }

            if (model.Password != model.PasswordTwo)
            {
                ModelState.AddModelError("", "رمز ورود یکسان نیست");
                return View(model);
            }

            var Newuser = new UserApp
            {
                UserName = model.UserName,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                CardId = model.CardId,
                Email = model.Email
            };
            var addResult = await userManager.CreateAsync(Newuser, model.Password);

            return View("Login");
        }

        public async Task<IActionResult> ForgotPass()
        {


            return View("ForgotPass");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
