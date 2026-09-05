using AutoMapper;
using SmartRecruitmentMatchingPlatform.API.Enums;
using SmartRecruitmentMatchingPlatform.API.Helpers;
using SmartRecruitmentMatchingPlatform.API.Models.DTOs.Auth;
using SmartRecruitmentMatchingPlatform.API.Models.Entities;
using SmartRecruitmentMatchingPlatform.API.Repositories;

namespace SmartRecruitmentMatchingPlatform.API.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    private readonly IMapper _mapper;

    public AuthService(
        IUserRepository userRepository,
        JwtTokenGenerator jwtTokenGenerator,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _mapper = mapper;
    }

    public async Task<AuthResponseDto> RegisterJobSeekerAsync(RegisterJobSeekerRequestDto request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
            throw new Exception("Email already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = PasswordHashHelper.HashPassword(request.Password),
            Role = UserRole.JobSeeker
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResponseDto
        {
            Token = token,
            Email = user.Email,
            Role = user.Role.ToString(),
            ExpiresAt = DateTime.UtcNow.AddMinutes(60)
        };
    }

    public async Task<AuthResponseDto> RegisterEmployerAsync(RegisterEmployerRequestDto request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
            throw new Exception("Email already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = PasswordHashHelper.HashPassword(request.Password),
            Role = UserRole.Employer
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResponseDto
        {
            Token = token,
            Email = user.Email,
            Role = user.Role.ToString(),
            ExpiresAt = DateTime.UtcNow.AddMinutes(60)
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
            throw new Exception("Invalid credentials.");

        if (!PasswordHashHelper.VerifyPassword(request.Password, user.PasswordHash))
            throw new Exception("Invalid credentials.");

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResponseDto
        {
            Token = token,
            Email = user.Email,
            Role = user.Role.ToString(),
            ExpiresAt = DateTime.UtcNow.AddMinutes(60)
        };
    }
}