using Application.Abstractions.Services.UserServices;
using Application.CQRS.User.Commands;
using Application.DTOs.User;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.CQRS.User.CommandHandlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserAddDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUserAuthValidationService _authValidation;

    public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, IUserAuthValidationService authValidation)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _authValidation = authValidation;
    }

    public async Task<UserAddDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userAddDto = request.UserAddDto;
        
        // Service can throw exceptions itself
        _authValidation.ValidateRegistration(userAddDto);

        var user = _mapper.Map<Domain.Entities.User>(userAddDto);
        await _userRepository.AddAsync(user);

        return userAddDto;
    }
}