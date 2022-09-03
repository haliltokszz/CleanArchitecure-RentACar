using FluentValidation;

namespace Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandValidator: AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MinimumLength(2).WithMessage("{PropertyName} must have at least 2 characters.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}