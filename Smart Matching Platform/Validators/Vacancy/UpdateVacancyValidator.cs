using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Vacancy;

namespace SmartRecruitmentMatchingPlatform.API.Validators.Vacancy
{
    public class UpdateVacancyValidator : AbstractValidator<UpdateVacancyRequestDto>
    {
        public UpdateVacancyValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Description)
                .MaximumLength(2000);

            RuleFor(x => x.Location)
                .MaximumLength(200);

            RuleFor(x => x.RequiredExperienceYears)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.EducationRequirement)
                .MaximumLength(500);

            RuleFor(x => x.SkillIds)
                .NotEmpty()
                .Must(x => x.Distinct().Count() == x.Count)
                .WithMessage("Duplicate skills are not allowed.");
        }
    }
}