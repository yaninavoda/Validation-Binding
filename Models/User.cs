
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ProductsValidation.Models
{
    public class User
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "{0} is obligatory and must be supplied in query string.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is obligatory and must be supplied in query string.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} is obligatory and must be supplied in query string.")]
        public string? Role { get; set; }
    }
}
