using Application.Abstractions.CustomExceptions.UserExceptions;
using Application.DTOs.User;

namespace Application.Abstractions.Services.UserServices;

public interface IUserAuthService
{
    /// <summary>
    /// Register new user
    /// </summary>
    /// <param name="userRegisterDto">A DTO containing new user information</param>
    /// <returns>User id in database table</returns>
    /// <exception cref="InvalidEmailException">Email is already used</exception>
    Task<int> Register(UserRegisterDto userRegisterDto);
    
    /// <summary>
    /// Logs in an existing user
    /// </summary>
    /// <param name="userLoginDto">A DTO containing info for the user</param>
    /// <returns>Stringified JWT Token</returns>
    /// <exception cref="WrongEmailException">User with given email was not found</exception>
    /// <exception cref="WrongPasswordException">Password given for current user was wrong</exception>
    Task<string> Login(UserLoginDto userLoginDto);
}