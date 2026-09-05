using FluentValidation;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;

namespace SmartRecruitmentMatchingPlatform.API.Validators.JobSeeker;

public class UploadCvValidator : AbstractValidator<UploadCvDto>
{
    private readonly string[] _allowedExtensions = { ".pdf", ".doc", ".docx" };

    public UploadCvValidator()
    {
        RuleFor(x => x.File)
            .NotNull()
            .Must(file => file.Length > 0)
            .WithMessage("Please select a file.");

        RuleFor(x => x.File)
            .Must(file =>
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                return _allowedExtensions.Contains(extension);
            })
            .WithMessage("Only PDF, DOC and DOCX files are allowed.");

        RuleFor(x => x.File)
            .Must(file => file.Length <= 5 * 1024 * 1024)
            .WithMessage("Maximum file size is 5 MB.");
    }
}