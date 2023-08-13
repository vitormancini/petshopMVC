using Microsoft.AspNetCore.Mvc;
using petshop.Models;
using petshop.Repositories.Interfaces;
using petshop.ViewModels;

namespace petshop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly Cart _cart;

        public CartController(IProductRepository productRepository, Cart cart)
        {
            _productRepository = productRepository;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var items = _cart.GetCartItems();
            _cart.CartItems = items;

            CartViewModel cartViewModel = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal()
            };

            return View(cartViewModel);
        }

        public RedirectToActionResult AddCartItem(int productId)
        {
            var product = _productRepository.GetProductById(productId);

            if (product != null)
            {
                _cart.AddItemToCart(product);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCartItem(int productId)
        {
            var product = _productRepository.GetProductById(productId);

            if (product != null)
            {
                _cart.RemoveItemFromCart(product);
            }

            return RedirectToAction("Index");
        }
    }
}
