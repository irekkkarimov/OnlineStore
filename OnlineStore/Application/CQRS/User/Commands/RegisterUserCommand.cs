using Application.DTOs.User;
using MediatR;

namespace Application.CQRS.User.Commands;

public record RegisterUserCommand(UserAddDto UserAddDto) : IRequest<UserAddDto>;