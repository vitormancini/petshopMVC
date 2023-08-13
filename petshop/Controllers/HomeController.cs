using Microsoft.AspNetCore.Mvc;
using petshop.Models;
using petshop.Repositories.Interfaces;
using petshop.ViewModels;
using System.Diagnostics;

namespace petshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepostory;

        public HomeController(IProductRepository productRepostory)
        {
            _productRepostory = productRepostory;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.HighlightedProducts = _productRepostory.Highlights;

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}