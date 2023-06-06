using Microsoft.AspNetCore.Mvc;

namespace WoodStock.Controllers
{
    public class LendingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
