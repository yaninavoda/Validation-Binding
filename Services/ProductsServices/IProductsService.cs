using ProductsValidation.Models;
using System.Collections.Generic;

namespace ProductsValidation.Services.ProductsServices
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProductsByCategory(Product.Category category);
    }
}
