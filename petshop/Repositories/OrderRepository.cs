using petshop.Context;
using petshop.Models;
using petshop.Repositories.Interfaces;

namespace petshop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly Cart _cart;

        public OrderRepository(AppDbContext dbContext, Cart cart)
        {
            _dbContext = dbContext;
            _cart = cart;
        }

        public void CreateOrder(Order order)
        {
            // Criando um pedido
            order.OrderSent = DateTime.Now;
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            // Com o pedido criado, montamos os detalhes deste pedido
            var cartItems = _cart.GetCartItems();

            foreach (var cartItem in cartItems) 
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity = cartItem.Quantity,
                    Product = cartItem.Product,
                    Order = order,
                    Price = cartItem.Product.Price
                };
                _dbContext.OrderDetails.Add(orderDetail);
            }
            _dbContext.SaveChanges();
        }
    }
}
