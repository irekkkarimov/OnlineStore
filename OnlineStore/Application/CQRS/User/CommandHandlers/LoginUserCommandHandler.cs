using Application.Abstractions.Services.UserServices;
using Application.CQRS.User.Commands;
using MediatR;

namespace Application.CQRS.User.CommandHandlers;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserAuthService _authService;
    private readonly IUserAuthValidationService _authValidationService;

    public LoginUserCommandHandler(IUserAuthService authService, IUserAuthValidationService authValidationService)
    {
        _authService = authService;
        _authValidationService = authValidationService;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var userLoginDto = request.UserLoginDto;

        // Service can throw exceptions itself
        _authValidationService.ValidateLogin(userLoginDto);

        var jwt = await _authService.Login(userLoginDto);
        return jwt;
    }
}