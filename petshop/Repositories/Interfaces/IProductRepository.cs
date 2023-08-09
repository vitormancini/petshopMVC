using petshop.Models;

namespace petshop.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> Highlights { get; }
        Product GetProductById(int id);
    }
}
