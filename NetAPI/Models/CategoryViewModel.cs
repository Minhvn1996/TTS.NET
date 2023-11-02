using FluentValidation;

namespace NetAPI.Models;

public class CategoryRequest
{
    public string? Name { set; get; }
}

public class CategoryRequestValidator : AbstractValidator<CategoryRequest>
{
    public CategoryRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is required")
            .MaximumLength(50).WithMessage("Category name can not over 50 characters limit");
    }
}
