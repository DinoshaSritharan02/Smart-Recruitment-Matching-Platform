using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Application;

namespace SmartRecruitmentMatchingPlatform.API.Validators.Application
{
    public class UpdateApplicationStatusValidator
        : AbstractValidator<UpdateApplicationStatusRequestDto>
    {
        public UpdateApplicationStatusValidator()
        {
            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Invalid application status.");
        }
    }
}