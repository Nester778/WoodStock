using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WoodStock.Models;
using WoodStock.ViewModels;

namespace WoodStock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Master> _userManager;
        private readonly SignInManager<Master> _signInManager;

        public HomeController(UserManager<Master> userManager, SignInManager<Master> signInManager,ILogger<HomeController> logger)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Master master = new Master { Email = model.Email, UserName = model.Email, Firstname =  model.Firstname,
                    Lastname = model.Lastname, CompanyName = model.CompanyName };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(master, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(master, false);
                    return RedirectToAction("LogIn", "LogIn");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}