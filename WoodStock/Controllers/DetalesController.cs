using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WoodStock.Models;
using WoodStock.Repo;

namespace WoodStock.Controllers
{
    public class DetalesController : Controller
    {
        private readonly WoodStockRepo _repo;
        public DetalesController(WoodStockRepo repo) 
        { 
            _repo = repo;
        }
        public IActionResult Detales(int id)
        {

            if (id > 0)
            {
                var currentUser = HttpContext.User;
                string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int MasterId = _repo.GetMasterId(userId);
                return View(_repo.GetProductById(id, MasterId));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Detales(Product product)
        {
            var currentUser = HttpContext.User;
            string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int MasterId = _repo.GetMasterId(userId);
            _repo.DeleteProd(product.Id_Product, MasterId);
            return RedirectToAction("Catalog", "Catalog");
        }
    }
}
