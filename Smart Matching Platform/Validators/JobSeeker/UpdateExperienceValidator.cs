using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

namespace SmartRecruitmentMatchingPlatform.API.Validators.JobSeeker;

public class UpdateExperienceValidator : AbstractValidator<UpdateExperienceDto>
{
    public UpdateExperienceValidator()
    {
        Include(new CreateExperienceValidator());
    }
}