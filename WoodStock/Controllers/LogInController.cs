using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WoodStock.Models;
using WoodStock.ViewModels;

namespace WoodStock.Controllers
{
    public class LogInController : Controller
    {
        private readonly SignInManager<Master> _signInManager;

        public LogInController(SignInManager<Master> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                        return RedirectToAction("Catalog", "Catalog");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }
    }
}
