using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

namespace SmartRecruitmentMatchingPlatform.API.Validators.JobSeeker;

public class UpdateEducationValidator : AbstractValidator<UpdateEducationDto>
{
    public UpdateEducationValidator()
    {
        Include(new CreateEducationValidator());
    }
}