using Microsoft.AspNetCore.Mvc;

namespace petshop.Controllers
{
    public class Contact : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
