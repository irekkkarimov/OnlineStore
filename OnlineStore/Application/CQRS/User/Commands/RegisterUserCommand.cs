using Application.DTOs.User;
using MediatR;

namespace Application.CQRS.User.Commands;

public record RegisterUserCommand(UserRegisterDto UserRegisterDto) : IRequest;