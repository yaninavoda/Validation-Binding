using ProductsValidation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProductsValidation.Models
{
    public class Product
    {
        private const double MIN_PRICE = 1d;
        private const double MAX_PRICE = 100000d;

        public enum Category 
        {   
            Toy,
            Technique,
            Clothes,
            Transport
        }

        public int Id { get; set; }
        public Category Type { get; set; }

        [Required]
        public string Name { get; set; }

        [DescriptionNameValidator]
        public string Description { get; set; }

        [Required]
        [Range(MIN_PRICE, MAX_PRICE, ErrorMessage = "{0} must be between 1 and 100000.")]
        public decimal Price { get; set; }

        public static IEnumerable<Category> GetCategories()
        {
            return Enum.GetValues(typeof(Category)).Cast<Category>();
        }
    }

    
}
