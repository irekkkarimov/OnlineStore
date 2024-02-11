using Application.DTOs.User;
using MediatR;

namespace Application.CQRS.User.Commands;

public record LoginUserCommand(UserLoginDto UserLoginDto) : IRequest<string>;