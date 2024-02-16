using ProductsValidation.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductsValidation.Services.ProductsServices
{ 
    public class ProductsService : IProductsService
    {
        private List<Product> _products;
        public ProductsService(Data data)
        {
            _products = data.Products;
        }

        public List<Product> GetProducts() 
        {
            return _products;
        }

        public Product? GetProductById(int id)
        {
            return _products.Find(x => x.Id == id);
        }

        public IEnumerable<Product?> GetProductsByCategory(Product.Category category) 
        {
            return _products.Where(item => item.Type == category);
        }

        public Product AddProduct() 
        {
            var newProduct = _products.Count > 0 ?
                new Product { Id = _products.Last().Id + 1 } :
                new Product { Id = 1 };
            
            return newProduct;
        }
    }
}
