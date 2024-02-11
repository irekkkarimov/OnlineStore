using System.Text.RegularExpressions;
using Application.Abstractions.CustomExceptions.UserExceptions;
using Application.Abstractions.Services.UserServices;
using Application.DTOs.User;

namespace Infrastructure.Services.UserServices;

public class UserAuthValidationService : IUserAuthValidationService
{
    private readonly Regex _emailRegexPattern = new(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
    public void ValidateRegistration(UserRegisterDto userRegisterDto)
    {
        ValidateUsername(userRegisterDto.Username);
        ValidateEmail(userRegisterDto.Email);
        ValidatePassword(userRegisterDto.Password);
    }

    public void ValidateLogin(UserLoginDto userLoginDto)
    {
        ValidateEmail(userLoginDto.Email);
        ValidatePassword(userLoginDto.Password);
    }

    private void ValidateUsername(string username)
    {
        if (username.Length < 5)
            throw new InvalidUsernameException("Username length is less than 5 characters");
    }

    private void ValidateEmail(string email)
    {
        if (!_emailRegexPattern.IsMatch(email))
            throw new InvalidEmailException("Email does not match the pattern");
    }

    private void ValidatePassword(string password)
    {
        if (password.Length < 6)
            throw new InvalidPasswordException("Password length is less than 6 characters");
    }
}