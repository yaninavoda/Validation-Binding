using ProductsValidation.Models;
using System.Collections.Generic;

namespace ProductsValidation.ViewModels
{
    public class GroupEditViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
