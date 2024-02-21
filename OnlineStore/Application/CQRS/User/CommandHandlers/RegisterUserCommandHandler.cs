using Application.Abstractions.Services.UserServices;
using Application.CQRS.User.Commands;
using Application.DTOs.User;
using AutoMapper;
using MediatR;

namespace Application.CQRS.User.CommandHandlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IUserAuthValidationService _authValidation;
    private readonly IUserAuthService _authService;
    private readonly IUserBalanceHandlerService _balanceHandler;


    public RegisterUserCommandHandler(IUserAuthService userAuthService, IUserAuthValidationService authValidation, IMapper mapper, IUserBalanceHandlerService balanceHandler)
    {
        _authService = userAuthService;
        _authValidation = authValidation;
        _balanceHandler = balanceHandler;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userRegisterDto = request.UserRegisterDto;
        
        // Service can throw exceptions itself
        _authValidation.ValidateRegistration(userRegisterDto);

        var userId = await _authService.Register(userRegisterDto);
        await _balanceHandler.CreateUserBalanceAsync(userId);
    }
}