using petshop.Models;

namespace petshop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> HighlightedProducts { get; set; }
    }
}
