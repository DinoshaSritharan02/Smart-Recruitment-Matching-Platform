using Microsoft.AspNetCore.Http;

namespace SmartRecruitmentMatchingPlatform.API.Services;

public interface ICvStorageService
{
    Task<string> UploadAsync(IFormFile file);

    Task DeleteAsync(string storedFileName);

    Task<FileStream> DownloadAsync(string storedFileName);
}