using petshop.Models;

namespace petshop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string Category { get; set; }
    }
}
