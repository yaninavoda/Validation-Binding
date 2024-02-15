using FluentValidation;
using ProductsValidation.Models;


namespace ProductsValidation.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        private const decimal _maxPrice = 100000.0m;
        public ProductValidator() 
        {
            RuleFor(product => product.Name).NotNull().NotEmpty();

            RuleFor(product => product.Description)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .When(product => !string.IsNullOrEmpty(product.Description))
            .Must((product, description) => description.StartsWith(product.Name) &&
                description.Length > product.Name.Length &&
                description.Length > 2)
            .WithMessage("Description must start with the product name and be longer than 2 characters.");

            RuleFor(product => product.Price).InclusiveBetween(1, _maxPrice);
        }
    }
}
