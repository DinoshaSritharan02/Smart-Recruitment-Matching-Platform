using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Auth;

namespace SmartRecruitmentMatchingPlatform.API.Validators.Auth
{
    public class RegisterEmployerValidator : AbstractValidator<RegisterEmployerRequestDto>
    {
        public RegisterEmployerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match.");
        }
    }
}