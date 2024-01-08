using FluentValidation;
using MyWatch.Models;

namespace MyWatch.Validator
{
    public class WatchValidator:AbstractValidator<WatchDetails>
    {
        public WatchValidator()
        {
            RuleFor(c => c.WatchName)
            .NotEmpty().WithMessage("Please Enter a Name")
            .Length(0, 10).WithMessage("Name length should be between 0 and 10 characters");
        }
    }
}
