using Microsoft.AspNetCore.Http;

namespace SmartRecruitmentMatchingPlatform.API.Services;

public class CvStorageService : ICvStorageService
{
    private readonly IWebHostEnvironment _environment;

    public CvStorageService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> UploadAsync(IFormFile file)
    {
        var uploadsFolder = Path.Combine(_environment.ContentRootPath, "Storage", "CVs");

        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        var path = Path.Combine(uploadsFolder, fileName);

        using var stream = new FileStream(path, FileMode.Create);

        await file.CopyToAsync(stream);

        return fileName;
    }

    public async Task DeleteAsync(string storedFileName)
    {
        var path = Path.Combine(
            _environment.ContentRootPath,
            "Storage",
            "CVs",
            storedFileName);

        if (File.Exists(path))
            await Task.Run(() => File.Delete(path));
    }

    public Task<FileStream> DownloadAsync(string storedFileName)
    {
        var path = Path.Combine(
            _environment.ContentRootPath,
            "Storage",
            "CVs",
            storedFileName);

        FileStream stream = new(path, FileMode.Open, FileAccess.Read);

        return Task.FromResult(stream);
    }
}