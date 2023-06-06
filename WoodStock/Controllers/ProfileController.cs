using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Claims;
using WoodStock.Models;
using WoodStock.Repo;
using WoodStock.ViewModels;

namespace WoodStock.Controllers
{
    public class ProfileController : Controller
    {
        private readonly WoodStockRepo _repo;
        private readonly SignInManager<Master> _signInMaster;

        public ProfileController(WoodStockRepo repo, SignInManager<Master> signInMaster)
        {
            _signInMaster = signInMaster;
            _repo = repo;
        }
        public IActionResult Profile()
        {
            ProfileViewModel model = new ProfileViewModel();
            var currentUser = HttpContext.User;
            string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int MasterId = _repo.GetMasterId(userId);
            Master master = _repo.GetMasterById(MasterId);
            model.Master = master;
            model.Position = "Master";
            model.Orders = _repo.GetOrders(MasterId);
            model.Colv = _repo.GetOrders(MasterId).Count();
            int sum = 0;
            foreach(var item in _repo.GetOrders(MasterId)) 
            {
                sum += item.Cost;
            }
            model.Sum = sum;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            var currentUser = HttpContext.User;
            string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int MasterId = _repo.GetMasterId(userId);
            Master master = _repo.GetMasterById(MasterId);

            await _signInMaster.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
