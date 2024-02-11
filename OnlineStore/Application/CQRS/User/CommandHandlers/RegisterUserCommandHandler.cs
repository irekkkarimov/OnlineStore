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


    public RegisterUserCommandHandler(IUserAuthService userAuthService, IUserAuthValidationService authValidation, IMapper mapper)
    {
        _authService = userAuthService;
        _authValidation = authValidation;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userRegisterDto = request.UserRegisterDto;
        
        // Service can throw exceptions itself
        _authValidation.ValidateRegistration(userRegisterDto);

        await _authService.Register(userRegisterDto);
    }
}