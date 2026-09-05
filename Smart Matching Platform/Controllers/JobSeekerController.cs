using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.JobSeeker;
using SmartRecruitmentMatchingPlatform.API.Services;

namespace SmartRecruitmentMatchingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "JobSeeker")]
public class JobSeekerController : ControllerBase
{
    private readonly IJobSeekerService _jobSeekerService;

    public JobSeekerController(IJobSeekerService jobSeekerService)
    {
        _jobSeekerService = jobSeekerService;
    }

    private Guid GetUserId()
    {
        return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var profile = await _jobSeekerService.GetProfileAsync(GetUserId());

        if (profile == null)
            return NotFound();

        return Ok(profile);
    }

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile(UpdateJobSeekerProfileDto dto)
    {
        await _jobSeekerService.UpdateProfileAsync(GetUserId(), dto);

        return NoContent();
    }

    [HttpPost("skills")]
    public async Task<IActionResult> AddSkill(AddSkillDto dto)
    {
        await _jobSeekerService.AddSkillAsync(GetUserId(), dto);

        return Ok();
    }

    [HttpDelete("skills/{skillName}")]
    public async Task<IActionResult> RemoveSkill(string skillName)
    {
        await _jobSeekerService.RemoveSkillAsync(GetUserId(), skillName);

        return NoContent();
    }
    [HttpPost("education")]
    public async Task<IActionResult> AddEducation(CreateEducationDto dto)
    {
        await _jobSeekerService.AddEducationAsync(GetUserId(), dto);

        return Ok();
    }

    [HttpPut("education/{educationId}")]
    public async Task<IActionResult> UpdateEducation(Guid educationId, UpdateEducationDto dto)
    {
        await _jobSeekerService.UpdateEducationAsync(educationId, dto);

        return NoContent();
    }

    [HttpDelete("education/{educationId}")]
    public async Task<IActionResult> DeleteEducation(Guid educationId)
    {
        await _jobSeekerService.DeleteEducationAsync(educationId);

        return NoContent();
    }

    [HttpPost("experience")]
    public async Task<IActionResult> AddExperience(CreateExperienceDto dto)
    {
        await _jobSeekerService.AddExperienceAsync(GetUserId(), dto);

        return Ok();
    }

    [HttpPut("experience/{experienceId}")]
    public async Task<IActionResult> UpdateExperience(Guid experienceId, UpdateExperienceDto dto)
    {
        await _jobSeekerService.UpdateExperienceAsync(experienceId, dto);

        return NoContent();
    }

    [HttpDelete("experience/{experienceId}")]
    public async Task<IActionResult> DeleteExperience(Guid experienceId)
    {
        await _jobSeekerService.DeleteExperienceAsync(experienceId);

        return NoContent();
    }

    [HttpGet("cv")]
    public async Task<IActionResult> GetCvMetadata()
    {
        var cv = await _jobSeekerService.GetCvMetadataAsync(GetUserId());

        if (cv == null)
            return NotFound();

        return Ok(cv);
    }
    [HttpPost("cv/upload")]
    public async Task<IActionResult> UploadCv([FromForm] UploadCvDto dto)
    {
        await _jobSeekerService.UploadCvAsync(GetUserId(), dto);

        return Ok(new
        {
            Message = "CV uploaded successfully."
        });
    }

    [HttpGet("cv/download")]
    public async Task<IActionResult> DownloadCv()
    {
        var result = await _jobSeekerService.DownloadCvAsync(GetUserId());

        return File(
            result.Stream,
            result.ContentType,
            result.FileName);
    }
}