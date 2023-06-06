using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WoodStock.Models;
using WoodStock.Repo;
using WoodStock.ViewModels;

namespace WoodStock.Controllers
{
    public class CreateOrderController : Controller
    {
        private readonly WoodStockRepo _repo;

        public CreateOrderController(WoodStockRepo repo)
        {
            _repo = repo;
        }
        public IActionResult CreateOrder(int id)
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            if (id > 0)
            {
                var currentUser = HttpContext.User;
                string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                int MasterId = _repo.GetMasterId(userId);
                orderViewModel.Product = _repo.GetProductById(id, MasterId);
                return View(orderViewModel);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel ovm)
        {
            var currentUser = HttpContext.User;
            string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Order order = new Order
            {
                Cost = ovm.Cost,
                Address = ovm.Address,
                ClientName = ovm.ClientName,
                CreateDate = DateTime.Now,
                Id_Master = _repo.GetMasterId(userId)
            };
            _repo.AddOrder(order);
            return RedirectToAction("Catalog", "Catalog");
        }
    }
}
