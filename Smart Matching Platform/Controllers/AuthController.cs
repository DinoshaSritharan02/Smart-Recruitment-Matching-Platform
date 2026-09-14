using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Auth;
using SmartRecruitmentMatchingPlatform.API.Services;
using FluentValidation;

namespace SmartRecruitmentMatchingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IValidator<RegisterJobSeekerRequestDto> _jobSeekerValidator;
    private readonly IValidator<RegisterEmployerRequestDto> _employerValidator;

    public AuthController(
        IAuthService authService,
        IValidator<RegisterJobSeekerRequestDto> jobSeekerValidator,
        IValidator<RegisterEmployerRequestDto> employerValidator)
    {
        _authService = authService;
        _jobSeekerValidator = jobSeekerValidator;
        _employerValidator = employerValidator;
    }

    [HttpPost("register/jobseeker")]
    public async Task<IActionResult> RegisterJobSeeker(RegisterJobSeekerRequestDto request)
    {
        var validation = await _jobSeekerValidator.ValidateAsync(request);

        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }

        var result = await _authService.RegisterJobSeekerAsync(request);
        return Ok(result);
    }

    [HttpPost("register/employer")]
    public async Task<IActionResult> RegisterEmployer(RegisterEmployerRequestDto request)
    {
        var validation = await _employerValidator.ValidateAsync(request);

        if (!validation.IsValid)
            return BadRequest(validation.Errors);

        var result = await _authService.RegisterEmployerAsync(request);
        return Ok(result);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        var result = await _authService.LoginAsync(request);

        return Ok(result);
    }
}