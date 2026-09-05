using Microsoft.AspNetCore.Mvc;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Auth;
using SmartRecruitmentMatchingPlatform.API.Services;

namespace SmartRecruitmentMatchingPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register/jobseeker")]
    public async Task<IActionResult> RegisterJobSeeker(RegisterJobSeekerRequestDto request)
    {
        var result = await _authService.RegisterJobSeekerAsync(request);

        return Ok(result);
    }

    [HttpPost("register/employer")]
    public async Task<IActionResult> RegisterEmployer(RegisterEmployerRequestDto request)
    {
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