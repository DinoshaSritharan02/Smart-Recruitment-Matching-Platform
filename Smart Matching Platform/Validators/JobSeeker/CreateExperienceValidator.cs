using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

namespace SmartRecruitmentMatchingPlatform.API.Validators.JobSeeker;

public class CreateExperienceValidator : AbstractValidator<CreateExperienceDto>
{
    public CreateExperienceValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.JobTitle)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Description)
            .MaximumLength(3000);

        RuleFor(x => x.StartDate)
            .NotEmpty();
    }
}