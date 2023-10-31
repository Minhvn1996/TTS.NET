using FluentValidation;

namespace NetAPI.Models;


public class AccountViewModel
{
    public string? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class RegisterRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PasswordCF { get; set; }
}

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password has to atleast 8 characters")
            .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
            .WithMessage("Password is not match complexity rules.");

        RuleFor(x => x.PasswordCF)
            .NotEmpty().WithMessage("Password confirm is required")
            .MinimumLength(8).WithMessage("Password confirm must have at least 8 characters")
            .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
            .WithMessage("Password confirm does not meet complexity rules.")
            .Equal(x => x.PasswordCF).WithMessage("Password and Confirm Password do not match.");

        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
            .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email format is not match");

        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
            .MaximumLength(50).WithMessage("First name can not over 50 characters limit");

        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
            .MaximumLength(50).WithMessage("Last name can not over 50 characters limit");

        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
            .MaximumLength(50).WithMessage("Last name can not over 50 characters limit");
    }
}

public class LoginRequest
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password has to atleast 8 characters")
            .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
            .WithMessage("Password is not match complexity rules.");

        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
            .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email format is not match");
    }
}