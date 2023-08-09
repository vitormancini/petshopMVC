using Microsoft.EntityFrameworkCore;
using petshop.Context;

namespace petshop.Models
{
    public class Cart
    {
        private readonly AppDbContext _context;

        public Cart(AppDbContext context)
        {
            _context = context;
        }

        public string CartId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            // Define uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // Obtem o serviço do tipo do nosso contento
            var context = services.GetService<AppDbContext>();

            // Obtem ou gera um novo Id de Cart (UUID)
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            // Atribui o Id do carrinho na sessão
            session.SetString("CartId", cartId);

            // Retorna o carrinho com o contexto e o Id do carrinho obtido ou atribuído
            return new Cart(context) { CartId = cartId };
        }

        public void AddItemToCart(Product product)
        {
            // Verifiando se na tabela CartItem já existe um produto com o mesmo Id do produto a ser adicionado
            // E também se já existe um Id de Cart com o mesmo Id de Cart obtido na session

            var cartItem = _context.CartItem.SingleOrDefault(s => s.Product.Id == product.Id && s.CartId == CartId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = CartId,
                    Product = product,
                    Quantity = 1
                };
                _context.CartItem.Add(cartItem);
            } else
            {
                cartItem.Quantity++;
            }

            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Product product) 
        {
            var cartItem = _context.CartItem.SingleOrDefault(s => s.Product.Id == product.Id && s.CartId == CartId);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                } else
                {
                    _context.CartItem.Remove(cartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems ??
                (CartItems = _context.CartItem
                                .Where(c => c.CartId == CartId)
                                .Include(s => s.Product)
                                .ToList());
        }

        public void CleanCart()
        {
            var cartItems = _context.CartItem.Where(cart => cart.CartId == CartId);

            _context.CartItem.RemoveRange(cartItems);
        }

        public decimal GetCartTotal()
        {
            var total = _context.CartItem.Where(c => c.CartId == CartId).Select(c => c.Product.Price * c.Quantity).Sum();

            return total;
        }
    }
}
