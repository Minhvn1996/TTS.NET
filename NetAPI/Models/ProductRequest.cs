using FluentValidation;

namespace NetAPI.Models;

public class ProductViewModel
{
    public int Id { set; get; }
    public string? CategoryName { set; get; }
    public string? Name { set; get; }
    public string? Description { set; get; }
    public decimal Price { set; get; }
    public bool Status { set; get; }
}

public class ProductRequest
{
    public int CategoryId { set; get; }
    public string? Name { set; get; }
    public string? Description { set; get; }
    public decimal Price { set; get; }
    public bool Status { set; get; }
}

public class ProductRequestValidator : AbstractValidator<ProductRequest>
{
    public ProductRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required")
            .MaximumLength(50).WithMessage("Product name can not over 50 characters limit");

        RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Description can not over 1000 characters limit");

        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}
