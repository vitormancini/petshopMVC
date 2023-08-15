using Microsoft.AspNetCore.Mvc;
using petshop.Models;
using petshop.Repositories.Interfaces;

namespace petshop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;

        public OrderController(IOrderRepository orderReository, Cart cart)
        {
            _orderRepository = orderReository;
            _cart = cart;
        }

        [HttpGet]
        public IActionResult Checkout() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ckeckout(Order order)
        {
            int orderTotalItems = 0;
            decimal orderTotalPrice = 0.0m;

            //Obtém os itens do carrinho de compra
            List<CartItem> cartItems = _cart.GetCartItems();
            _cart.CartItems = cartItems;

            // Verifica se existem itens de pedido
            if (_cart.CartItems.Count > 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio");
            }

            // Calculando o total de itens e o total de pedidos
            foreach (var item in cartItems)
            {
                orderTotalItems += item.Quantity;
                orderTotalPrice += item.Product.Price * item.Quantity;
            }

            // Atribui os valores obtidos ao pedido
            order.Total = orderTotalPrice;
            order.TotalOrderItems = orderTotalItems;

            // Valida os dados do pedido
            if (ModelState.IsValid)
            {
                // Cria os pedidos
                _orderRepository.CreateOrder(order);

                ViewBag.CheckoutCompleted = "Obrigado por comprar conosco!";
                ViewBag.TotalOrder = _cart.GetCartTotal();

                // Limpa o carrinho
                _cart.CleanCart();

                return View("~/Views/Order/OrderCompleted.cshtml", order);
            }

            return View(order);
        }
    }
}
