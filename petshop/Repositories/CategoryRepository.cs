using petshop.Context;
using petshop.Models;
using petshop.Repositories.Interfaces;

namespace petshop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> AllCategories => _context.Categories;
    }
}
