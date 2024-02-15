using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsValidation.Models
{
    public class Product
    {
        //private const double maxPriceAllowed = 100000d;
        public enum Category 
        {   
            Toy,
            Technique,
            Clothes,
            Transport
        }

        public int Id { get; set; }
        public Category Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public static IEnumerable<Category> GetCategories()
        {
            return Enum.GetValues(typeof(Category)).Cast<Category>();
        }
    }

    
}
