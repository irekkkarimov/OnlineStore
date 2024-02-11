using Application.DTOs.User;

namespace Application.Abstractions.Services.UserServices;

public interface IUserAuthService
{
    Task Register(UserRegisterDto userRegisterDto);
    Task<string> Login(UserLoginDto userLoginDto);
}