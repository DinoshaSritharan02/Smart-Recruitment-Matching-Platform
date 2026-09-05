using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

namespace SmartRecruitmentMatchingPlatform.API.Validators.JobSeeker;

public class CreateEducationValidator : AbstractValidator<CreateEducationDto>
{
    public CreateEducationValidator()
    {
        RuleFor(x => x.Institution)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Degree)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.FieldOfStudy)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.StartDate)
            .NotEmpty();
    }
}