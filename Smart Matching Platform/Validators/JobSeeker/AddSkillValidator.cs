using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

namespace SmartRecruitmentMatchingPlatform.API.Validators.JobSeeker;

public class AddSkillValidator : AbstractValidator<AddSkillDto>
{
    public AddSkillValidator()
    {
        RuleFor(x => x.SkillName)
            .NotEmpty()
            .MaximumLength(100);
    }
}