using FluentValidation;
using Smart_Matching_Platform.Models.DTOs.Application;

namespace Smart_Matching_Platform.Validators.Application
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