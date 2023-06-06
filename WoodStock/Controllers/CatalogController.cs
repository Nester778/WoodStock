using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WoodStock.Repo;
using WoodStock.ViewModels;

namespace WoodStock.Controllers
{
    public class CatalogController : Controller
    {
        private readonly WoodStockRepo _repo;
        public CatalogController(WoodStockRepo woodStockRepo)
        { 
            _repo = woodStockRepo;
        }
        public IActionResult Catalog()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = HttpContext.User;
                string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int MasterId = _repo.GetMasterId(userId);
                var prod = _repo.GetProducts(MasterId);
                CatalogViewModel catalogViewModel = new CatalogViewModel { Products = prod };
                return View(catalogViewModel);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Catalog(CatalogViewModel cvm)
        {
            var currentUser = HttpContext.User;
            string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int MasterId = _repo.GetMasterId(userId);
            var prod = _repo.GetProducts(MasterId);
            var res = prod;
            if (cvm.Search != null)
                res = prod.Where(x => x.Title == cvm.Search).ToList();


            CatalogViewModel catalogViewModel = new CatalogViewModel { Products = res };
            return View(catalogViewModel);
        }
    }
}
