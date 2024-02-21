using Application.Abstractions.CustomExceptions.UserExceptions;
using Application.DTOs.User;

namespace Application.Abstractions.Services.UserServices;

public interface IUserAuthValidationService
{
    /// <summary>
    /// Validates new User registration
    /// </summary>
    /// <param name="userRegisterDto">A DTO containing information about new User</param>
    /// <exception cref="InvalidUsernameException">Username length was less than 5 characters</exception>
    /// <exception cref="InvalidEmailException">Email did not match the pattern</exception>
    /// <exception cref="InvalidPasswordException">"Password length was less than 6 characters"</exception>
    void ValidateRegistration(UserRegisterDto userRegisterDto);

    /// <summary>
    /// Validates logging in an existing User
    /// </summary>
    /// <param name="userLoginDto">A DTO containing information about the User to login</param>
    /// <exception cref="InvalidEmailException">Email did not match the pattern</exception>
    /// <exception cref="InvalidPasswordException">"Password length was less than 6 characters"</exception>
    void ValidateLogin(UserLoginDto userLoginDto);
}