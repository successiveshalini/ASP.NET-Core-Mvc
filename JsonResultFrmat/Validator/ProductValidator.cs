using FluentValidation;
using JsonResultFormate.Models;

namespace JsonResultFormate.Validator
{
    public class ProductValidator: AbstractValidator<ProductDetails>
    {
        public ProductValidator()
        {
            RuleFor(c => c.ProductName)
                .NotEmpty().WithMessage("Please enter a name")
                .Length(0, 10).WithMessage("Name length should be between 0 and 10 characters");
        }
    }
}
