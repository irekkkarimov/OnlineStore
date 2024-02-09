using System.Text.RegularExpressions;
using Application.Abstractions.CustomExceptions.Abstractions;
using Application.Abstractions.CustomExceptions.UserExceptions;
using Application.Abstractions.Services.UserServices;
using Application.DTOs.User;

namespace Infrastructure.Services;

public class UserAuthValidationService : IUserAuthValidationService
{
    private readonly Regex _emailRegexPattern = new(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
    public void ValidateRegistration(UserAddDto userAddDto)
    {
        ValidateUsername(userAddDto.Username);
        ValidateEmail(userAddDto.Email);
        ValidatePassword(userAddDto.Password);
    }

    public void ValidateLogin(UserLoginDto userLoginDto)
    {
        ValidateEmail(userLoginDto.Email);
        ValidatePassword(userLoginDto.Password);
    }

    private void ValidateUsername(string username)
    {
        if (username.Length < 5)
            throw new InvalidUsernameException("Username's length is less than 5 characters");
    }

    private void ValidateEmail(string email)
    {
        if (!_emailRegexPattern.IsMatch(email))
            throw new InvalidEmailException("Email does not match the pattern");
    }

    private void ValidatePassword(string password)
    {
        if (password.Length < 6)
            throw new InvalidPasswordException("Password's length is less than 6 characters");
    }
}