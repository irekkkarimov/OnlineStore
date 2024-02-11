using Application.DTOs.User;

namespace Application.Abstractions.Services.UserServices;

public interface IUserAuthValidationService
{
    void ValidateRegistration(UserRegisterDto userRegisterDto);
    void ValidateLogin(UserLoginDto userLoginDto);
}