using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Abstractions.CustomExceptions.UserExceptions;
using Application.Abstractions.Services.UserServices;
using Application.DTOs.User;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services.UserServices;

public class UserAuthService : IUserAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public UserAuthService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<int> Register(UserRegisterDto userRegisterDto)
    {
        var allUsers = await _userRepository.GetAllAsync();

        if (allUsers.FirstOrDefault(i => i.Email.Equals(userRegisterDto.Email)) is not null)
            throw new InvalidEmailException("Email is already used");

        var newUser = _mapper.Map<User>(userRegisterDto);
        await _userRepository.AddAsync(newUser);
        return newUser.Id;
    }

    public async Task<string> Login(UserLoginDto userLoginDto)
    {
        var allUsers = await _userRepository.GetAllAsync();
        var tryToFindCurrentUser = allUsers.FirstOrDefault(i => i.Email.Equals(userLoginDto.Email));

        if (tryToFindCurrentUser is null)
            throw new WrongEmailException("Email not found");

        if (!tryToFindCurrentUser.Password.Equals(userLoginDto.Password))
            throw new WrongPasswordException("Wrong password");

        return CreateToken(tryToFindCurrentUser);
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new("userid", user.Id.ToString()),
            new("email", user.Email),
            new("username", user.Username),
            new Claim("role", user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("JWT_SECRET_TOKEN").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}