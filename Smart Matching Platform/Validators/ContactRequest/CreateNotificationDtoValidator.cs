using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.DTOs.Notifications;

namespace SmartRecruitmentMatchingPlatform.API.Validators
{
    public class CreateNotificationDtoValidator : AbstractValidator<CreateNotificationDto>
    {
        public CreateNotificationDtoValidator()
        {
            RuleFor(x => x.UserId)
              .NotEmpty()
               .WithMessage("A valid User ID is required.");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(100)
                .WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage("Message is required.")
                .MaximumLength(500)
                .WithMessage("Message cannot exceed 500 characters.");
        }
    }
}