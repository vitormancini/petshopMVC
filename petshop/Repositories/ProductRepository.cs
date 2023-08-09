using Microsoft.EntityFrameworkCore;
using petshop.Context;
using petshop.Models;
using petshop.Repositories.Interfaces;

namespace petshop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context= context;
        }

        public IEnumerable<Product> AllProducts => _context.Products.Include(c => c.Category);

        public IEnumerable<Product> Highlights => _context.Products.Where(p => p.Highlighted).Include(c => c.Category);

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
