using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.DTOs.Admin;

namespace SmartRecruitmentMatchingPlatform.API.Validators
{
    public class UpdateUserStatusDtoValidator : AbstractValidator<UpdateUserStatusDto>
    {
        public UpdateUserStatusDtoValidator()
        {
            RuleFor(x => x.IsActive)
                .NotNull()
                .WithMessage("User status is required.");
        }
    }
}