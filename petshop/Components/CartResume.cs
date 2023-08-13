using Microsoft.AspNetCore.Mvc;
using petshop.Models;
using petshop.ViewModels;

namespace petshop.Components
{
    public class CartResume : ViewComponent
    {
        private readonly Cart _cart;

        public CartResume(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
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
    }
}
