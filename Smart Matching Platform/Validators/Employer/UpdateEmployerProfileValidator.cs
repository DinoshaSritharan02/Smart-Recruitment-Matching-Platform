using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Employer;

namespace SmartRecruitmentMatchingPlatform.API.Validators.Employer
{
    public class UpdateEmployerProfileValidator
        : AbstractValidator<UpdateEmployerProfileRequestDto>
    {
        public UpdateEmployerProfileValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage("Company name is required.")
                .MaximumLength(200)
                .WithMessage("Company name must not exceed 200 characters.");

            RuleFor(x => x.CompanyDescription)
                .MaximumLength(1000)
                .WithMessage("Company description must not exceed 1000 characters.");

            RuleFor(x => x.Industry)
                .MaximumLength(100)
                .WithMessage("Industry must not exceed 100 characters.");

            RuleFor(x => x.CompanyLocation)
                .MaximumLength(200)
                .WithMessage("Company location must not exceed 200 characters.");

            RuleFor(x => x.Website)
                .MaximumLength(500)
                .WithMessage("Website must not exceed 500 characters.");
        }
    }
}