using Microsoft.AspNetCore.Mvc;
using petshop.Models;
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

        public IActionResult List(string category)
        {
            IEnumerable<Product> products;
            string currentCategory = String.Empty;

            if (String.IsNullOrEmpty(category)) 
            {
                products = _productRepository.AllProducts.OrderBy(p => p.Id);
                currentCategory = "Todos os produtos";
            } else
            {
                products = _productRepository.AllProducts.Where(p => p.Category.Name == category);
                currentCategory = category;
            }

            var productViewModel = new ProductListViewModel();
            productViewModel.Products = products;
            productViewModel.Category= currentCategory;

            return View(productViewModel);
        }
        public IActionResult Detail(int productId)
        {
            var product = _productRepository.GetProductById(productId);
            return View(product);
        }
        public ViewResult Search(string productName)
        {
            IEnumerable<Product> products;  
            string currentCategory = String.Empty;

            if(String.IsNullOrEmpty(productName)) 
            {
                products = _productRepository.AllProducts.OrderBy(p => p.Name);
                currentCategory = "Todos os produtos";
            } else
            {
                products = _productRepository.AllProducts.Where(p => p.Name.ToLower().Contains(productName.ToLower()));

                if (products.Any()) 
                {
                    currentCategory = "Produtos";
                } else
                {
                    currentCategory = "Nenhum produto encontrado";
                }
            }

            ProductListViewModel productListViewModel = new ProductListViewModel()
            {
                Products = products,
                Category = currentCategory,
            };

            return View("~/Views/Product/List.cshtml", productListViewModel);
        }
    }
}
