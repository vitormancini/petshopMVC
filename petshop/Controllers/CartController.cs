using Microsoft.AspNetCore.Mvc;

namespace petshop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
