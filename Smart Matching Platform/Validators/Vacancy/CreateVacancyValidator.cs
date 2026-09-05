using FluentValidation;
using Smart_Matching_Platform.Models.DTOs.Vacancy;

namespace Smart_Matching_Platform.Validators.Vacancy
{
    public class CreateVacancyValidator
        : AbstractValidator<CreateVacancyRequestDto>
    {
        public CreateVacancyValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Vacancy title is required.")
                .MaximumLength(200)
                .WithMessage("Vacancy title must not exceed 200 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(2000)
                .WithMessage("Description must not exceed 2000 characters.");

            RuleFor(x => x.Location)
                .MaximumLength(200)
                .WithMessage("Location must not exceed 200 characters.");

            RuleFor(x => x.RequiredExperienceYears)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Required experience years cannot be negative.");

            RuleFor(x => x.EducationRequirement)
                .MaximumLength(500)
                .WithMessage("Education requirement must not exceed 500 characters.");

            RuleFor(x => x.SkillIds)
                .NotEmpty()
                .WithMessage("At least one required skill must be selected.");

            RuleForEach(x => x.SkillIds)
                .GreaterThan(0)
                .WithMessage("Skill ID must be greater than zero.");
        }
    }
}