using Microsoft.AspNetCore.Mvc;
using petshop.Repositories.Interfaces;
using petshop.ViewModels;

namespace petshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Acessar o repositório Product método List
        public IActionResult List()
        {
            ProductListViewModel productViewModel = new ProductListViewModel();
            productViewModel.Products = _productRepository.AllProducts;

            productViewModel.Category = "Categoria";

            return View(productViewModel);
        }
    }
}
