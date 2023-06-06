using Microsoft.AspNetCore.Mvc;

namespace WoodStock.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test()
        {
            return View();
        }
    }
}
